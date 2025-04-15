using Lab2;
UserInterface userInterface = new UserInterface();
Logic logic = new Logic();
LibraryBook book = logic.CreateLibraryBook();

userInterface.ShowMessage(book.GetInfo());
book.BorrowBook();
userInterface.ShowMessage("After borrowing the book:");
userInterface.ShowMessage(book.GetInfo());

book.BorrowBook();

book.ReturnBook();
userInterface.ShowMessage("After returning the book:");
string bookInfo = book.GetInfo();
userInterface.ShowMessage(bookInfo);