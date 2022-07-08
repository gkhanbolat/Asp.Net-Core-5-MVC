# Asp.Net-Core-5-MVC

Create Trigger AddBlogInRaytingTable
On Blogs
After Insert
As
Declare @ID int
Select @ID=BlogID from inserted
Insert into BlogRatings(BlogID,BlogTotalScore,BlogRatingCount)
Values(@ID,0,0)


--------------------------------------------------------------------


Create Trigger AddScoreInComment
On Comments
After Insert
As
Declare @ID int
Declare @Score int
Declare @RatingCount int
Select @ID=BlogID,@Score=BlogScore from inserted
Update BlogRatings set BlogTotalScore=BlogTotalScore+@Score, BlogRatingCount+=1
Where BlogID=@ID
