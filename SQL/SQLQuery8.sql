-- user-defined functions

create function ComputeEmpNetSalary(@basic money, @hra tinyint, @ta tinyint)
returns money
begin
   declare @netsal money
   set @netsal = (@basic + (@basic * CONVERT(money, (@hra))/100 ) + 
   (@basic * CONVERT(money, (@ta))/100 ))
   return @netsal
end

select EmpId, emp.Name,
  dept.Name as 'DeptName',
  grd.[Title],grd.[Basic],
  -- since there is some computation done on the basic column we have to give an alias to it
  dbo.ComputeEmpNetSalary(grd.[Basic], grd.[HRA], grd.[TA]) as 'NetSalary'
  from
Employees emp inner join Departments dept
on emp.DeptId = dept.DeptId
inner join Grade grd
on emp.GradeId = grd.GradeId
where emp.Status=1