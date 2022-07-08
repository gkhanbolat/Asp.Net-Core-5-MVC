# Asp.Net-Core-5-MVC

Create Trigger AddBlogInRaytingTable
On Blogs
After Insert
As
Declare @ID int
Select @ID=BlogID from inserted
Insert into BlogRatings(BlogID,BlogTotalScore,BlogRatingCount)
Values(@ID,0,0)
