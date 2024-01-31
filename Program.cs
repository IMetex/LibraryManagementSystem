using System;
using LibraryManagementSystem.controller;
using LibraryManagementSystem.Managers;

namespace LibraryManagementSystem
{
    class Program
    {
        public static void Main(string[] args)
        {
            LibraryController libraryController = new LibraryController(new MemberActionsManager(),
                new LibraryActionsManager(), new BookActionsManager());
            libraryController.Start();
        }
    }
}