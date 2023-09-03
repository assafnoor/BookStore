﻿using BookStore.Models;

namespace BookStore.Dto
{
    public class AuthorDetailsDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<string> books { get; set; }
    }
}
