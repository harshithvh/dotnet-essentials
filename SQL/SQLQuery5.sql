select * from Employees

select * from Departments

select * from Grade

-- inner join is a type of join operation that combines rows from two or more tables based on a matching condition. 
-- It returns only the rows that have matching values in both tables.

-- Get All Employee who are active 
-- ignore the error
create view GetAllActiveUsers
with encryption
as
select EmpId, emp.Name, DOB, DOJ, -- Ambiguous error if emp.Name is not used, Ambiguous means two tables have the same column name
  case Gender
  when 'M' then 'Male'
  when 'F' then 'Female'
  -- end keyword marks the end of the CASE statement -- as 'Gender', creates an alias
  -- since there is some computation done on the gender column we have to give an alias to it
  end as 'Gender',
  dept.Name as 'DeptName' from
Employees emp inner join Departments dept
-- emp.DeptId is a foreign key that references to the DeptId of the Departments table
on emp.DeptId = dept.DeptId
where emp.Status=1 -- show all emp information who are active

select * from GetAllActiveUsers

-- try removing the 'with encryption' above to see the difference
sp_helptext 'GetAllActiveUsers'

--Get All Employee salary details
create view GetEmployeeSalary
as
select EmpId, emp.Name,
  dept.Name as 'DeptName',
  grd.[Title],grd.[Basic],
  -- since there is some computation done on the basic column we have to give an alias to it
  -- convert tinyint to money datatype
  (grd.[Basic] + (grd.[Basic] * CONVERT(money, (grd.[HRA]))/100 ) + 
  (grd.[Basic] * CONVERT(money, (grd.[TA]))/100 )) as 'NetSalary'
  from
Employees emp inner join Departments dept
on emp.DeptId = dept.DeptId
inner join Grade grd
on emp.GradeId = grd.GradeId
where emp.Status=1 -- show all emp information who are active

--Get All employees on name
create view GetEmployeeByName
as
select EmpId,emp.[Name],
	convert(nvarchar(10), DOB,101) as 'DOB' ,DOJ,
  case Gender
  when 'M' then 'Male'
  when 'F' then 'Female'
  end as 'Gender',
  dept.[Name] as 'DeptName'      from 
Employees  emp inner join Departments dept
on emp.DeptId = dept.DeptId
where emp.[Status]=1 and  emp.[Name] like 'a%'

--Get  employee on id
alter view GetEmployeeById
with encryption
as
select EmpId,emp.[Name],
	convert(nvarchar(10), DOB,101) as 'DOB' ,DOJ,
  case Gender
  when 'M' then 'Male'
  when 'F' then 'Female'
  end as 'Gender',
  dept.[Name] as 'DeptName'      from 
Employees  emp inner join Departments dept
on emp.DeptId = dept.DeptId
where emp.[Status]=1 and  emp.[EmpId]=1