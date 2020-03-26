namespace Ex1
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Models;

    internal class Program
    {
        private static void Main(string[] args)
        {
            List<User> allUsers = ReadUsers("users.json");
            List<Post> allPosts = ReadPosts("posts.json");

            #region Demo

            // 1 - find all users having email ending with ".net".
            Console.WriteLine("1 - find all users having email ending with .net");
            var users1 = from user in allUsers
                         where user.Email.EndsWith(".net")
                         select user;

            var users11 = allUsers.Where(user => user.Email.EndsWith(".net"));

            IEnumerable<string> userNames = from user in allUsers
                                            select user.Name;

            var userNames2 = allUsers.Select(user => user.Name);

            foreach (var value in userNames2)
            {
                Console.WriteLine(value);
            }

            IEnumerable<Company> allCompanies = from user in allUsers
                                                select user.Company;

            var users2 = from user in allUsers
                         orderby user.Email
                         select user;

            var netUser = allUsers.First(user => user.Email.Contains(".net"));
            Console.WriteLine(netUser.Username);

            #endregion

            // 2 - find all posts for users having email ending with ".net".
            Console.WriteLine(System.Environment.NewLine + "2 - find all posts for users having email ending with .net");
            IEnumerable<int> usersIdsWithDotNetMails = from user in allUsers
                                                       where user.Email.EndsWith(".net")
                                                       select user.Id;

            IEnumerable<Post> posts = from post in allPosts
                                      where usersIdsWithDotNetMails.Contains(post.UserId)
                                      select post;

            foreach (var post in posts)
            {
                Console.WriteLine(post.Id + " " + "user: " + post.UserId);
            }

            // 3 - print number of posts for each user.
            Console.WriteLine(System.Environment.NewLine + "3 - print number of posts for each user.");

            var postsCounter = allPosts.GroupBy(post => post.UserId)
                   .OrderBy(post => post.Key)
                   .ToDictionary(grp => grp.Key, grp => grp.Count());

            foreach (var x in postsCounter)
            {
                Console.WriteLine("User with id " + x.Key + " has: " + x.Value + " posts");
            }

            // 4 - find all users that have lat and long negative.
            Console.WriteLine(System.Environment.NewLine + "4 - find all users that have lat and long negative.");
            var negCoordinatesUsers = allUsers.Where(user => user.Address.Geo.Lat < 0 && user.Address.Geo.Lng < 0)
            .OrderBy(user => user.Id)
            .Select(user => new { user.Name, user.Address });

            foreach (var x in negCoordinatesUsers)
            {
                Console.WriteLine(x.Name + " has lat " + x.Address.Geo.Lat + " and lng " + x.Address.Geo.Lng);
            }

            // 5 - find the post with longest body.
            Console.WriteLine(System.Environment.NewLine + "5 - find the post with longest body.");
            var postsBodyLen = allPosts.OrderByDescending(post => post.Body.Length)
                .Select(post => new { post.Id, post.UserId });
            Console.WriteLine("The id of the longest body post is {0}", postsBodyLen.First().Id);


            // 6 - print the name of the employee that have post with longest body.
            Console.WriteLine(System.Environment.NewLine + "6 - print the name of the employee that have post with longest body.");
            var userWithLongestPost = allUsers.Where(user => user.Id == postsBodyLen.First().UserId)
                .Select(user => user.Name);
            Console.WriteLine(userWithLongestPost.First());

            // 7 - select all addresses in a new List<Address>. print the list.
            Console.WriteLine(System.Environment.NewLine + "7 - select all addresses in a new List<Address>. print the list.");

            var list = (from user in allUsers
                        select new Address
                        {
                            Street = user.Address.Street,
                            Suite = user.Address.Suite,
                            City = user.Address.City,
                            Zipcode = user.Address.Zipcode,
                            Geo = user.Address.Geo
                        }).ToList();

            foreach (var address in list)
            {
                Console.WriteLine(address.City + ", " + address.Street + ", " + address.Suite + ", " + address.Zipcode + ", " + address.Geo.Lat + ", " + address.Geo.Lng);
            }


            // 8 - print the user with min lat
            Console.WriteLine(System.Environment.NewLine + "8 - print the user with min lat");
            var minLat = allUsers
            .OrderBy(user => user.Address.Geo.Lat)
            .Select(user => new { user.Id, user.Name, user.Address.Geo.Lat });

            Console.WriteLine("User with the min lat : id " + minLat.First().Id + ", name " + minLat.First().Name + ", lat " + minLat.First().Lat);


            // 9 - print the user with max long
            Console.WriteLine(System.Environment.NewLine + "9 - print the user with max long");
            var maxLong = allUsers
            .OrderByDescending(user => user.Address.Geo.Lng)
            .Select(user => new { user.Id, user.Name, user.Address.Geo.Lng });

            Console.WriteLine("User with the max long : id " + maxLong.First().Id + ", name " + maxLong.First().Name + ", long " + maxLong.First().Lng);

            // 10 - create a new class: public class UserPosts { public User User {get; set}; public List<Post> Posts {get; set} }
            //    - create a new list: List<UserPosts>
            //    - insert in this list each user with his posts only
            Console.WriteLine(System.Environment.NewLine + "10 - create a new class: public class UserPosts { public User User {get; set}; public List<Post> Posts {get; set} }");
            var userPostsList = (from user in allUsers
                                 select new UserPosts
                                 {
                                     User = user,
                                     Posts = (from post in allPosts
                                              where post.UserId == user.Id
                                              select post
                                              ).ToList()
                                 }).ToList();

            foreach (var userPost in userPostsList)
            {
                Console.WriteLine("User " + userPost.User.Name + " has a total of " + userPost.Posts.Count + " posts");
            }


            // 11 - order users by zip code
            Console.WriteLine(System.Environment.NewLine + "11 - order users by zip code");
            var zipCodeUsers = allUsers
            .OrderBy(user => user.Address.Zipcode)
            .Select(user => new { user.Id, user.Name, user.Address.Zipcode });

            foreach (var zipCodeUser in zipCodeUsers) 
            {
                Console.WriteLine(zipCodeUser.Name + ", zip code: " + zipCodeUser.Zipcode);
            }

            // 12 - order users by number of posts
            Console.WriteLine(System.Environment.NewLine + "12 - order users by number of posts");
            var usersByPostsNo = (from user in allUsers
                                 select new 
                                 {
                                     User = user,
                                     NoOfPosts = (from post in allPosts
                                              where post.UserId == user.Id
                                              select post
                                              ).ToList().Count
                                 }).ToList().OrderByDescending(user => user.NoOfPosts);

            foreach (var userPostsOrder in usersByPostsNo)
            {
                Console.WriteLine("User " + userPostsOrder.User.Name + " has a total of " + userPostsOrder.NoOfPosts + " posts");
            }
        }

        private static List<Post> ReadPosts(string file)
        {
            return ReadData.ReadFrom<Post>(file);
        }

        private static List<User> ReadUsers(string file)
        {
            return ReadData.ReadFrom<User>(file);
        }
    }
}