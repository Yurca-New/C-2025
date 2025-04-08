using Lab2;
UserInterface userInterface = new UserInterface();
LibraryBook book = new LibraryBook("1984", "George Orwell");

userInterface.ShowMessage(book.GetInfo());
book.BorrowBook();
userInterface.ShowMessage("After borrowing the book:");
userInterface.ShowMessage(book.GetInfo());

book.BorrowBook();

book.ReturnBook();
userInterface.ShowMessage("After returning the book:");
userInterface.ShowMessage(book.GetInfo());