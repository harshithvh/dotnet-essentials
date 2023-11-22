use EmpMgmt

--creates a new table named "Departments" with two columns
create table [Departments] (
-- "DeptId" - a primary key column of data type "tinyint" that auto-increments by 1 starting from 1.
-- "IDENTITY(1,1)" specifies that the "DeptId" column will auto-increment by 1 starting from 1.
-- "CONSTRAINT pk_dept_id PRIMARY KEY" specifies that the "DeptId" column is the primary key for the table and gives it the name "pk_dept_id".
-- a primary key constraint ensures that the values in the primary key column(s) are unique and cannot be null.
[DeptId] tinyint not null identity(1,1) constraint pk_dept_id primary key,
[Name] nvarchar(50) not null
)

select * from INFORMATION_SCHEMA.TABLES
select * from INFORMATION_SCHEMA.TABLE_CONSTRAINTS
select * from INFORMATION_SCHEMA.CHECK_CONSTRAINTS

sp_help 'departments'

create table [Grade] (
[GradeId] int not null identity(1,1) constraint pk_grade_id primary key,
[Title] nvarchar(50) not null,
[Basic] money not null,
[TA] tinyint not null constraint chk_grade_ta check (TA > 0 and TA < 25),
[HRA] tinyint not null constraint chk_grade_hra check (HRA > 0 and HRA < 30)
)

create table [Employees] (
[EmpId] int not null identity(1,1) constraint pk_emp_id primary key,
[Name] nvarchar(50) not null,
-- chk_emp_dob is the name of the check constraint that validates the given condition
DOB date not null constraint chk_emp_dob check (DOB < GetDate()),
DOJ date null constraint def_emp_doj default getdate(),
Gender nchar(1) null constraint def_emp_gen default 'M',
DeptId tinyint not null constraint fk_emp_deptid foreign key references [Departments]([DeptId]),
GradeId int not null constraint fk_emp_grdid foreign key references [Grade]([GradeId]),
Email nvarchar(50) not null,
[Password] nvarchar(50) not null,
[Status] tinyint null constraint def_emp_status default 1 -- 1-Ongoing, 2-Completed, 3-Pending
)
