﻿using System;

public class GoldenEditionBook : Book
{
    public GoldenEditionBook(string author, string title, decimal price)
        : base(author, title, price * 1.3M)
    { }
}
