using Lab2;
UserInterface userInterface = new UserInterface();
LibraryBook book = userInterface.CreateLibraryBook();

userInterface.ShowMessage(book.GetInfo());
book.BorrowBook();
userInterface.ShowMessage("After borrowing the book:");
userInterface.ShowMessage(book.GetInfo());

book.BorrowBook();

book.ReturnBook();
userInterface.ShowMessage("After returning the book:");
string bookInfo = book.GetInfo();
userInterface.ShowMessage(bookInfo);