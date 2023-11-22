using Microsoft.EntityFrameworkCore;
using TravelBlog.Entitiy;

namespace TravelBlog.Data.Concrete.EfCore
{
     public static class SeedData{

        public static void TestVeriliniDoldur(IApplicationBuilder app){
            var context = app.ApplicationServices.CreateScope().ServiceProvider.GetService<BlogContext>();

            if(context != null){

                if(context.Database.GetPendingMigrations().Any()){
                    context.Database.Migrate();
                }

                if(!context.Tags.Any()){
                    context.Tags.AddRange(
                    new Entitiy.Tag {Text = "İstanbul", Url="istanbul-gezi", Color = TagColors.success},
                    new Entitiy.Tag {Text = "Bursa", Url="bursa-gezi", Color = TagColors.warning},
                    new Entitiy.Tag {Text = "Trabzon", Url="trabzon-gezi", Color = TagColors.danger},
                    new Entitiy.Tag {Text = "Kayseri", Url="kayseri-gezi", Color = TagColors.info}
                    );
                    context.SaveChanges();
                }
                if(!context.Users.Any()){
                    context.Users.AddRange(
                    new Entitiy.User{UserName = "alperen", Name="Alperen KARA",Email="info@alperenkara.com",Password="123456", Image  = "man.jpg" },
                    new Entitiy.User{UserName = "Zeynep",Name="Zeynep KARA",Email="info@zeynepkara.com",Password="123456", Image  = "woman.jpg" }
                    );
                    context.SaveChanges();
                }
                if(!context.Posts.Any()){
                    context.Posts.AddRange(
                    new Entitiy.Post{
                        Title = "İstanbul",
                        Content = "Hakkında", 
                        Description="Güzeldir",
                        Url="istanbul-gezi",                   
                        IsActive = true,  
                        Image  = "1.jpg",                   
                        PublishedOn = DateTime.Now,
                        Tags = context.Tags.Take(3).ToList(),
                        UserId = 1,
                        Comments = new List<Comment>{
                            new Comment {Text = "Güzel", PublishedOn = new DateTime(),UserId = 1},
                            new Comment {Text = "Güzel", PublishedOn = new DateTime(),UserId = 2}
                    }
                       
                    },
                     new Entitiy.Post{
                        Title = "Bursa",
                        Content = "Hakkında",
                        Description="Güzeldir",
                        Url="bursa-gezi",                       
                        IsActive = true, 
                        Image  = "2.jpg",                       
                        PublishedOn = DateTime.Now,
                        Tags = context.Tags.Take(3).ToList(),
                        UserId = 1
                    
                    },
                     new Entitiy.Post{
                        Title = "Trabzon",
                        Content = "Hakkında",
                        Description="Güzeldir",
                        Url="trabzon-gezi",                       
                        IsActive = true,
                        Image  = "3.jpg",                         
                        PublishedOn = DateTime.Now,
                        Tags = context.Tags.Take(3).ToList(),
                        UserId = 1
                    }

                    );
                    context.SaveChanges();
                }
            }
        }
    }
}