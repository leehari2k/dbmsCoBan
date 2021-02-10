create or alter view Taikhoan_view as
select tentk as N'Tên tài khoản', loaitk as N'Loại tài khoản'
from Taikhoan
go

create or alter view Khachhang_view as
select maKh , ho , tenlot ,tenKh , ngaysinh , loaiKh 
from Khachhang
go

create or alter view ThueTN_view as
select t.maphong , kh.ho+ ' '+ kh.tenlot +' ' +  kh.tenKh as HotenKH
			, t.ngaythue , t.ngaytra , t.tinhtrang , t.tongiten , t.maThue
from Thue t, Khachhang kh
where t.maKh = kh.maKh
go

create or alter view ThueAd_view as
select t.maphong , kh.ho+ ' '+ kh.tenlot +' ' +  kh.tenKh as HotenKH
			, t.ngaythue , t.ngaytra , t.tinhtrang , t.tongiten , nv.manv , nv.ho + ' ' + nv.tenlot +' '+nv.tennv as HotenNV, t.maThue
from Thue t, Khachhang kh, Nhanvien nv
where t.maKh = kh.maKh and nv.manv = t.nguoiCapnhat
go


create or alter trigger tg_InUpNhanvien on Nhanvien
for insert, update
as
begin
	declare @ngaysinh date

	select  @ngaysinh = ngaysinh from inserted

	if DATEDIFF(YEAR,@ngaysinh,getdate()) < 18
	begin		
		print N'Nhân viên phải trên 18 tuổi'
		rollback tran
		return
	end 
end
go

create or alter trigger tg_InKhachHang on Khachhang
for insert, update
as
begin
	declare @ngaysinh date

	select @ngaysinh =  ngaysinh from inserted
	if datediff(year,@ngaysinh,getdate()) < 18
		begin
			print N'Khách hàng phải từ 18 tuổi trở lên'
			rollback tran
			return
		end
end
go

create or alter trigger tg_InNhanvien on Nhanvien
for insert
as
begin
	declare @ngaysinh date,
			@tentk  int,
			@loaitk nvarchar(50)
	select @tentk = manv,  @loaitk = chucvu, @ngaysinh = ngaysinh from inserted
 
	if @loaitk = N'Quản lý' 
	insert into Taikhoan values(@tentk,'1111','admin')
	else if @loaitk = N'Thu ngân'
	insert into Taikhoan values(@tentk,'1111','TN')
end
go
--update tình trạng của Phong khi có người Thuê
 create or alter trigger tg_InThue on Thue
 for insert
 as
 begin
	declare @maphong char(10)

	select @maphong =  maphong from inserted

	update Phong
	set tinhtrang = 'N'
	where maphong = @maphong

 end
 go


create or alter function f_kiemtratrangthai(@maphong char(5))
returns int
as
	begin 
		declare @trangthai char(1),
				@kq int

		select @trangthai = tinhtrang from Phong where @maphong = maphong

		if @trangthai = 'N'
			begin
				set @kq = 1
				return @kq
			end
		else if @trangthai = 'Y'
			begin
				set @kq = 0
				return @kq
			end
		return -1
	end
go


select dbo.f_kiemtratrangthai('A220')
go

create or alter function f_dangnhap(@taikhoan int,@matkhau nvarchar(50),@loaitk nvarchar(50))
returns int
as
begin
	if @loaitk = N'admin'
		begin 
			if (select count(*) from Taikhoan where tentk = @taikhoan and matkhau = @matkhau and loaitk = @loaitk) =1
			return 1
		end
	else if @loaitk = N'TN'
		begin
			if (select count(*) from Taikhoan where tentk = @taikhoan and matkhau = @matkhau and loaitk = @loaitk) = 1
			return 1
		end

	return 0
end
go
create or alter proc sp_datphong
	@maphong char(10),
	@makh int,
	@mancc int
as
begin tran
	begin try
		if @maphong = '' or @makh = '' or @mancc = '' 
			begin
				rollback tran
				return
			end
	end try
	begin catch
		begin
			rollback tran
			return
		end
	end catch
	declare @mathue int
	set @mathue = 1
	while exists(select * from Thue where maThue = @mathue)
	set @mathue = @mathue + 1

	insert into Thue values (@mathue,@maphong, @makh, getdate(),null,'N','',@maNcc)

commit tran
go

begin tran
exec sp_datphong 'A203','3','2'
commit tran
go
-- Procedure trả phòng
create or alter proc sp_traphong
	@maphong char(5),
	@maThue int,
	@mancc int
as
begin tran
	
	declare @songay int,
		@tien money,
		@ngaythue date

	select @tien = giaphong from Phong where maphong =@maphong
	select @ngaythue = ngaythue from Thue where @maThue = maThue
	set @songay = datediff(day,@ngaythue,getdate())

	update Thue
	set tinhtrang = 'Y', ngaytra = getdate(), tongiten = @songay * @tien, nguoiCapnhat =@mancc
	where @maThue = maThue

	update Phong
	set tinhtrang = 'Y'
	where @maphong = maphong
	
commit tran
go

begin tran
exec sp_traphong 'A201',4,2
select * from Thue where maThue = 4
rollback tran
go

create or alter proc sp_loadDSTP
	@tukhoa nvarchar(50),
	@loaitk nvarchar(50),
	@trangthai char(1)
as
begin 
	if @loaitk = 'TN'
		begin
			if @trangthai = 'A'
				select maphong as N'Mã phòng', HotenKH as N'Họ tên KH', ngaythue as N'Ngày thuê', ngaytra as N'Ngày trả',
								tinhtrang as N'Trạng thái', tongiten as N'Tổng tiền', maThue as N'Mã số thuê'
				from ThueTN_view where lower(HotenKH) like '%'+lower(@tukhoa)+'%'
			else if @trangthai = 'N'
				select maphong as N'Mã phòng', HotenKH as N'Họ tên KH', ngaythue as N'Ngày thuê', ngaytra as N'Ngày trả',
								tinhtrang as N'Trạng thái', tongiten as N'Tổng tiền' , maThue as N'Mã số thuê'
				from ThueTN_view where lower(HotenKH) like '%'+lower(@tukhoa)+'%'
												and tinhtrang = 'N'
			else if @trangthai = 'Y'
				select maphong as N'Mã phòng', HotenKH as N'Họ tên KH', ngaythue as N'Ngày thuê', ngaytra as N'Ngày trả',
								tinhtrang as N'Trạng thái', tongiten as N'Tổng tiền' , maThue as N'Mã số thuê'
				from ThueTN_view where lower(HotenKH) like '%'+lower(@tukhoa)+'%' and tinhtrang = 'Y'
		end
	else if @loaitk = 'admin'
		begin
			if @trangthai = 'A'
				select maphong as N'Mã phòng', HotenKH as N'Họ tên KH', ngaythue as N'Ngày thuê', ngaytra as N'Ngày trả',
								tinhtrang as N'Trạng thái', tongiten as N'Tổng tiền', manv as N'Mã nhân viên', HotenNV as N'Họ tên NV', maThue as N'Mã số thuê'
				from ThueAd_view where lower(HotenKH) like '%'+lower(@tukhoa)+'%'
												or lower(HotenNV) like '%' + lower(@tukhoa) + '%'
			else if @trangthai = 'N'
				select maphong as N'Mã phòng', HotenKH as N'Họ tên KH', ngaythue as N'Ngày thuê', ngaytra as N'Ngày trả',
								tinhtrang as N'Trạng thái', tongiten as N'Tổng tiền', manv as N'Mã nhân viên', HotenNV as N'Họ tên NV', maThue as N'Mã số thuê'
				from ThueAd_view where tinhtrang = 'N' and (lower(HotenKH) like '%'+lower(@tukhoa)+'%'
												or lower(HotenNV) like '%' + lower(@tukhoa) + '%')
												
			else if @trangthai = 'Y'
				select maphong as N'Mã phòng', HotenKH as N'Họ tên KH', ngaythue as N'Ngày thuê', ngaytra as N'Ngày trả',
								tinhtrang as N'Trạng thái', tongiten as N'Tổng tiền', manv as N'Mã nhân viên', HotenNV as N'Họ tên NV', maThue as N'Mã số thuê'
				from ThueAd_view where tinhtrang = 'Y'  and (lower(HotenKH) like '%'+lower(@tukhoa)+'%'
												or lower(HotenNV) like '%' + lower(@tukhoa) + '%')
		end
end
go
exec sp_loadDSTP '','admin','A'
go

create or alter proc sp_loadDSKH
@tukhoa nvarchar(50),
@loaitk nvarchar(50)
as
begin tran
	begin try
		if not exists (select * from Khachhang)
		begin 
			rollback tran
			return
		end
	end try

	begin catch
		rollback tran
		return
	end catch
	if @loaitk = 'Admin'
		select maKh as N'Mã khách hàng', ho +' '+ tenlot +' '+ tenKh as N'Họ và tên', ngaysinh as N'Ngày sinh', loaiKh as N'Cấp độ', nguoiCapnhat as N'Mã người cập nhật'
		from Khachhang 
		where lower(ho) like '%'+lower(@tukhoa)+'%'
		or lower(tenlot) like '%' + lower(@tukhoa) + '%'
		or lower(tenKh) like '%' + lower(@tukhoa) + '%'
		or lower(loaiKh) like '%' + lower(@tukhoa) + '%'
	else if @loaitk = 'TN'
		select *
		from Khachhang_view
		where lower(ho) like '%'+lower(@tukhoa)+'%'
		or lower(tenlot) like '%' + lower(@tukhoa) + '%'
		or lower(tenKh) like '%' + lower(@tukhoa) + '%'
		or lower(loaiKh) like '%' + lower(@tukhoa) + '%'
commit tran
go
exec sp_loadDSKH 'VIP','Admin'
go

create or alter proc sp_thongtincn
	@tentk int
as
begin tran
	select nv.ho + ' '+nv.tenlot+' '+ nv.tennv as N'hovaten' , nv.ngaysinh,nv.sdt,nv.chucvu  
	from Nhanvien nv where @tentk = nv.manv
commit tran
go

create or alter proc sp_xoakh
	@makh int
as
begin tran
	delete from Khachhang where @makh = maKh
commit tran
go
create or alter proc sp_themkh
	@ho nvarchar(50),
	@tenlot nvarchar(50),
	@tenkh nvarchar(50),
	@sdt varchar(50),
	@ngaysinh date,
	@mancn int
as
begin tran
	begin try
		if @ho = '' or @tenkh = '' or @tenlot = '' or @sdt = ''
		begin
			print N'Không được bỏ trống'
			rollback tran
			return
		end
	end try
	begin catch
		print N'Lỗi nha'
		return
	end catch
	declare @makh int

	set @makh = 1
	while exists (select * from Khachhang where maKh = @makh)
	set @makh = @makh + 1

	insert into Khachhang values (@makh, @ho, @tenlot,@tenkh,@sdt,@ngaysinh,N'Thường',@mancn)
commit tran
go

create or alter proc sp_suakh
	@makh int,
	@ho nvarchar(50),
	@tenlot nvarchar(50),
	@tenkh nvarchar(50),
	@sdt varchar(50),
	@ngaysinh date,
	@loaiKh nvarchar(20),
	@mancn int
as
begin tran
	update Khachhang
	set ho = @ho, tenlot = @tenlot, tenKh = @tenkh, @sdt =sdt , ngaysinh = @ngaysinh, loaiKh = @loaiKh, nguoiCapnhat = @mancn
	where @makh = maKh
commit tran
go

create or alter proc sp_chonKh
	@makh int
as
begin tran
	select * from Khachhang where maKh = @makh
commit tran
go

exec sp_chonKh 1

go
create or alter proc sp_selectLoaikh
as
begin tran
	select distinct loaiKh from Khachhang
commit tran
go
exec sp_selectLoaikh
go

create or alter proc sp_loadnv
	@tukhoa nvarchar(50)
as
begin tran
	begin try
		if not exists (select * from Nhanvien)
		begin 
			print N'Không tồn tại nhân viên'
			rollback tran
			return
		end
	end try

	begin catch
		rollback tran
		return
	end catch

	select manv as N'Mã nhân viên', ho +' '+ tenlot +' '+ tennv as N'Họ và tên',ngaysinh as N'Ngày sinh' , sdt as N'Số điện thoại', chucvu as N'Chức vụ'
	from Nhanvien
	where lower(ho) like '%'+lower(@tukhoa)+'%'
	or lower(tenlot) like '%' + lower(@tukhoa) + '%'
	or lower(tennv) like '%' + lower(@tukhoa) + '%'
	or lower(chucvu) like '%' + lower(@tukhoa) + '%'
commit tran
go

create or alter proc sp_suanv
	@manv int,
	@ho nvarchar(50),
	@tenlot nvarchar(50),
	@ten nvarchar(50),
	@ngaysinh date,
	@sdt varchar(50),
	@chucvu nvarchar(50)
as
begin tran
	begin try
		if @ho = '' or @tenlot = '' or @ten = '' or @sdt = '' or (@chucvu != N'Thu ngân' and @chucvu != N'Quản lý')
		begin
			rollback tran
			return
		end
	end try
	begin catch
		rollback tran
		return
	end catch

	update Nhanvien 
	set ho = @ho, tenlot = @tenlot, tennv = @ten, sdt = @sdt, ngaysinh = @ngaysinh, chucvu = @chucvu
	where manv = @manv
commit tran
go

create or alter proc sp_themnv
	@ho nvarchar(50),
	@tenlot nvarchar(50),
	@ten nvarchar(50),
	@ngaysinh date,
	@sdt varchar(50),
	@chucvu nvarchar(50)
as
begin tran
	begin try
		if @ho = '' or @tenlot = '' or @ten = '' or @sdt = '' or (@chucvu != N'Thu ngân' and @chucvu != N'Quản lý')
		begin
			rollback tran
			return
		end
	end try
	begin catch
		rollback tran
		return
	end catch

	declare @manv int

	set @manv = 1
	while exists(select * from Nhanvien where @manv = manv)
	set @manv = @manv + 1

	insert into Nhanvien values (@manv,@ho,@tenlot,@ten,@ngaysinh,@sdt,@chucvu)
commit tran
go

create or alter proc sp_xoanv
	@manv int
as
begin tran
	delete from Taikhoan where tentk = @manv
	delete from Nhanvien where @manv = manv
commit tran
go

create or alter proc sp_loainv
as
begin
	select distinct chucvu from Nhanvien
end
go


create or alter proc sp_chonnv
	@manv int
as
begin
	select * from Nhanvien where @manv = manv
end	
go

create or alter proc sp_loadDSP
	@tinhtrang char(1)
as
begin
	if @tinhtrang = 'A'
	select stt as N'Số thứ tự', maphong as N'Mã phòng', loaiphong as N'Loại phòng',
				capdo as N'Cấp độ', giaphong as N'Giá phòng (VNĐ)', tinhtrang as N'Tình trạng'
	from Phong order by stt
	else
	select stt as N'Số thứ tự', maphong as N'Mã phòng', loaiphong as N'Loại phòng',
				capdo as N'Cấp độ', giaphong as N'Giá phòng (VNĐ)', tinhtrang as N'Tình trạng' 
	from Phong
	where tinhtrang like '%' + @tinhtrang  + '%' order by stt
end
go

exec sp_loadDSP 'A'
go

create or alter proc sp_themphong
	@maphong char(5),
	@loaiphong nvarchar(20),	
	@capdo nvarchar(50),
	@giaphong money,
	@tinhtrang char(1)
as
begin tran
	begin try
		if @maphong = '' or @loaiphong = '' or @giaphong = '' or @capdo = '' or (@tinhtrang != 'Y' and @tinhtrang != 'N' )
		begin 
			rollback tran
			return
		end
	end try

	begin catch
		rollback tran
			return
	end catch
	
	declare @stt int
	set @stt = 1
	while exists (select * from Phong where @stt = stt)
		set @stt = @stt + 1

	insert into Phong values(@stt,@maphong,@loaiphong,@capdo,@giaphong,@tinhtrang)
commit tran
go

exec sp_themphong 'A211',N'Đơn','VIP',500000,'Y'
select * from Phong 
go

create or alter proc sp_xoaphong
	@maphong char(5)
as 
begin tran
	delete from Phong where maphong = @maphong
commit tran
go

exec sp_xoaphong 'A212'
select * from Phong 
go

create or alter proc sp_suaphong
	@maphong char(5),
	@loaiphong nvarchar(20),	
	@capdo nvarchar(50),
	@giaphong money,
	@tinhtrang char(1)
as
begin tran
	begin try
		if @maphong = '' or @loaiphong = '' or @giaphong = '' or @capdo = '' or (@tinhtrang != 'Y' and @tinhtrang != 'N' )
		begin 
			rollback tran
			return
		end
	end try

	begin catch
		rollback tran
			return
	end catch
	
	update Phong
	set capdo = @capdo, loaiphong = @loaiphong, giaphong = @giaphong,tinhtrang= @tinhtrang
	where maphong = @maphong

commit tran
go

exec sp_suaphong 'A212',N'Đôi',N'Thường',500000,'Y'
select * from Phong 
go

select distinct loaiphong from Phong
select distinct capdo from Phong
select distinct tinhtrang from Phong

go

create or alter proc sp_chonphong
	@maphong char(5)
as
begin
	select * from Phong where maphong = @maphong
end
go

exec sp_chonphong 'A201'
go

create index index_thue_tinhtrang
on thue (tinhtrang)
go
create index index_phong_tinhtrang
on phong(tinhtrang)
go


/*tạo login*/
sp_addlogin 'admin', '1234'
go
sp_addlogin 'thungan','1234'
go
-- tạo user ứng với login
sp_adduser 'admin', 'admin'
go
sp_adduser 'thungan','thungan'
go
-- thêm quyền admin: toàn quyền
sp_addsrvrolemember [admin],[sysadmin]
go
-- tạo role thu ngân và thêm nhân viên vào role thu ngân
--tạo role thu ngân
sp_addrole [RoleThuNgan]
go
--Thêm nhân viên vào RoleThuNgan
sp_addrolemember [RoleThuNgan],[thungan]
go
--Thêm các quyền vào RoleThuNgan
--trên bảng
Grant select, insert, update on Khachhang to RoleThuNgan
Grant select, update on Phong to RoleThuNgan
Grant select, insert, update on Thue to RoleThuNgan
--trên view
grant select, insert,update on Khachhang_view to RoleThuNgan
grant select, insert, update on ThueTN_view to RoleThuNgan
--trên proce
Grant exec on sp_chonKh to RoleThuNgan
Grant exec on sp_chonphong to RoleThuNgan
grant exec on sp_datphong to RoleThuNgan
grant exec on sp_loadDSKH to RoleThuNgan
grant exec on sp_loadDSP to RoleThuNgan
grant exec on sp_loadDSTP to RoleThuNgan
grant exec on sp_suaphong to RoleThuNgan
grant exec on sp_themkh to RoleThuNgan
grant exec on sp_selectLoaikh to RoleThuNgan
grant exec on sp_suakh to RoleThuNgan
grant exec on sp_thongtincn to RoleThuNgan
grant exec on sp_traphong to RoleThuNgan 
--trên func
grant exec on f_dangnhap to RoleThuNgan
grant exec on f_kiemtratrangthai to RoleThuNgan

