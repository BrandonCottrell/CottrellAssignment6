using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using CottrellAssignment6.Context;
using CottrellAssignment6.Models;

namespace CottrellAssignment6.Services;

public class MainService : IMainService
{
    private readonly IFileService _fileService;
    public MainService(IFileService fileService)
    {
        _fileService = fileService;
    }

    public void Invoke()
    {

        MediaContext context = new MediaContext();

        List<Media> media = new List<Media>();
        var movies = context.Movies;
        var shows = context.Shows;
        var videos = context.Videos;

        media.AddRange(context.Movies);
        media.AddRange(context.Videos);
        media.AddRange(context.Shows);

        Console.WriteLine("Which media would you like to display?");
        Console.WriteLine("1. Movies");
        Console.WriteLine("2. Shows");
        Console.WriteLine("3. Videos");
        Console.WriteLine("4. All");
        var userInput = Console.ReadLine();

        if (userInput == "1")
        {
            foreach (var m in movies) // shows, movies, videos
            {
                m.Display();
            }
        } else if (userInput == "2")
        {
            foreach (var m in shows) // shows, movies, videos
            {
                m.Display();
            }
        } else if (userInput == "3")
        {
            foreach (var m in videos) // shows, movies, videos
            {
                m.Display();
            }
        } else if (userInput == "4")
        {
            foreach (var m in media) // shows, movies, videos
            {
                m.Display();
            }
        } else
        {
            Console.WriteLine("Not a valid input");
        }



    }
}








//public class currentCode
//{
//    string file = "";
//    Console.WriteLine("Which media would you like to see?");
//        Console.WriteLine("1. Movies");
//        Console.WriteLine("2. Shows");
//        Console.WriteLine("3. Videos");
//        var mediaChoice = Console.ReadLine();

//        if (mediaChoice == "1")
//        {
//            file = "Data/movies.csv";
//        } else if (mediaChoice == "2")
//        {
//            file = "Data/shows.csv";
//        } else if (mediaChoice == "3")
//{
//    file = "Data/videos.csv";
//}

////string movieFile = "Data/movies.csv";
////string showFile = "Data/shows.csv";
////string videoFile = "Data/videos.csv";


//if (!File.Exists(file))
//{
//    Console.WriteLine("The file does not exist");
//}
//else
//{
//    string choice;
//    do
//    {
//        // display choices to user
//        Console.WriteLine("1) Add Media");
//        Console.WriteLine("2) View All Media");
//        Console.WriteLine("Enter to quit");

//        // input selection
//        choice = Console.ReadLine();
//        Console.WriteLine($"User Choice: {choice}");

//        // create parallel lists of movie details
//        // lists must be used since we do not know number of lines of data
//        List<UInt64> MediaIds = new List<UInt64>();
//        List<string> MovieTitles = new List<string>();
//        List<string> MovieGenres = new List<string>();
//        // to populate the lists with data, read from the data file
//        try
//        {
//            StreamReader sr = new StreamReader(file);
//            // first line contains column headers
//            sr.ReadLine();
//            while (!sr.EndOfStream)
//            {
//                string line = sr.ReadLine();
//                // first look for quote(") in string
//                // this indicates a comma(,) in movie title
//                int idx = line.IndexOf('"');
//                if (idx == -1)
//                {
//                    // no quote = no comma in movie title
//                    // movie details are separated with comma(,)
//                    string[] movieDetails = line.Split(',');
//                    // 1st array element contains movie id
//                    MediaIds.Add(UInt64.Parse(movieDetails[0]));
//                    // 2nd array element contains movie title
//                    MovieTitles.Add(movieDetails[1]);
//                    // 3rd array element contains movie genre(s)
//                    // replace "|" with ", "
//                    MovieGenres.Add(movieDetails[2].Replace("|", ", "));
//                }
//                else
//                {
//                    // quote = comma in movie title
//                    // extract the movieId
//                    MediaIds.Add(UInt64.Parse(line.Substring(0, idx - 1)));
//                    // remove movieId and first quote from string
//                    line = line.Substring(idx + 1);
//                    // find the next quote
//                    idx = line.IndexOf('"');
//                    // extract the movieTitle
//                    MovieTitles.Add(line.Substring(0, idx));
//                    // remove title and last comma from the string
//                    line = line.Substring(idx + 2);
//                    // replace the "|" with ", "
//                    MovieGenres.Add(line.Replace("|", ", "));
//                }
//            }
//            // close file when done
//            sr.Close();
//        }
//        catch (Exception ex)
//        {
//            Console.WriteLine(ex.Message);
//        }
//        Console.WriteLine($"Movies in file {MediaIds.Count}");

//        if (choice == "1")
//        {
//            // Add Movie
//            // ask user to input movie title
//            Console.WriteLine("Enter the movie title");
//            // input title
//            string movieTitle = Console.ReadLine();
//            // check for duplicate title
//            List<string> LowerCaseMovieTitles = MovieTitles.ConvertAll(t => t.ToLower());
//            if (LowerCaseMovieTitles.Contains(movieTitle.ToLower()))
//            {
//                Console.WriteLine("That movie has already been entered");
//                Console.WriteLine($"Duplicate movie title {movieTitle}");
//            }
//            else
//            {
//                // generate movie id - use max value in MovieIds + 1
//                UInt64 movieId = MediaIds.Max() + 1;
//                // input genres
//                List<string> genres = new List<string>();
//                string genre;
//                do
//                {
//                    // ask user to enter genre
//                    Console.WriteLine("Enter genre (or done to quit)");
//                    // input genre
//                    genre = Console.ReadLine();
//                    // if user enters "done"
//                    // or does not enter a genre do not add it to list
//                    if (genre != "done" && genre.Length > 0)
//                    {
//                        genres.Add(genre);
//                    }
//                } while (genre != "done");
//                // specify if no genres are entered
//                if (genres.Count == 0)
//                {
//                    genres.Add("(no genres listed)");
//                }
//                // use "|" as delimeter for genres
//                string genresString = string.Join("|", genres);
//                // if there is a comma(,) in the title, wrap it in quotes
//                movieTitle = movieTitle.IndexOf(',') != -1 ? $"\"{movieTitle}\"" : movieTitle;
//                // display movie id, title, genres
//                Console.WriteLine($"{movieId},{movieTitle},{genresString}");
//                // create file from data
//                StreamWriter sw = new StreamWriter(file, true);
//                sw.WriteLine($"{movieId},{movieTitle},{genresString}");
//                sw.Close();
//                // add movie details to Lists
//                MediaIds.Add(movieId);
//                MovieTitles.Add(movieTitle);
//                MovieGenres.Add(genresString);
//                // log transaction
//                Console.WriteLine($"Movie added");
//            }
//        }
//        else if (choice == "2")
//        {


//            //for (int i = 0; i < MediaIds.Count; i++)
//            //{
//            //    // display movie details
//            //    Console.WriteLine($"Id: {MediaIds[i]}");
//            //    Console.WriteLine($"Title: {MovieTitles[i]}");
//            //    Console.WriteLine($"Genre(s): {MovieGenres[i]}");
//            //    Console.WriteLine();


//            //}

//        }
//    } while (choice == "1" || choice == "2");
//}
