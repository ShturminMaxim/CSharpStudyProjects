CREATE database MaxTest
on (
name = MaxTest,
filename = 'D:\Shturmin\maxtest.mdf',
size = 7MB,
maxsize = 199MB,
filegrowth = 2MB
)
log on (
	name = MaxTest_Log,
	filename = 'D:\Shturmin\maxtest.ldf',
	size = 7MB,
	maxsize = 199MB,
	filegrowth = 10%
)