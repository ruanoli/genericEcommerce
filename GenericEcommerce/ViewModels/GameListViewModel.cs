﻿using GenericEcommerce.Models;

namespace GenericEcommerce.ViewModels
{
    public class GameListViewModel
    {
        public IEnumerable<Game>? Games { get; set; }
        public string? CurrentCategory { get; set; }
    }
}
