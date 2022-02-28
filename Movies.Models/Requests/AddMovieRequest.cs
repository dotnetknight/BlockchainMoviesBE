﻿namespace Movies.Models.Requests
{
    public class AddMovieRequest
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Director { get; set; }

        public string SenderAddress { get; set; }
    }
}
