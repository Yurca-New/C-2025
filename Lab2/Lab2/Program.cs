using Lab2;
UserInterface userInterface = new UserInterface();
LibraryService libraryService = new LibraryService(userInterface);
LibraryBook book = libraryService.CreateLibraryBook();

string initialInfo = book.GetInfo();
userInterface.ShowMessage(initialInfo);

bool borrowed = book.BorrowBook();
userInterface.ShowMessage("After borrowing the book:");
string borrowedInfo = book.GetInfo();
userInterface.ShowMessage(borrowedInfo);

bool secondBorrowAttempt = book.BorrowBook();
if (!secondBorrowAttempt)
{
    userInterface.ShowError("Cannot borrow the book again. It is already borrowed.");
}

book.ReturnBook();
userInterface.ShowMessage("After returning the book:");
string returnedInfo = book.GetInfo();
userInterface.ShowMessage(returnedInfo);