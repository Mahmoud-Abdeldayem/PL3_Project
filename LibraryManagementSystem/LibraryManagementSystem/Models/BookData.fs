module BookData


open System

/// Record to represent a book
type Book = {
    Title: string
    Author: string
    Genre: string
    Status: string // "Available" or "Borrowed" 
    IsBorrowed: bool
    BorrowedBy: string option
    BorrowDate: System.DateTime option
}


/// Mutable map to store books
let mutable booksMap: Map<string, Book> = Map.empty // map key will the book title which is string, map is mutable to be able to add to it
//let mutable  BorrowedBooksMap: Map<string, Book> = Map.empty 


///// List to store books
//let booksList = [
//    { Title = "To Kill a Mockingbird"; 
//      Author = "Harper Lee"; 
//      Genre = "Fiction"; 
//      Status = "Available"; 
//      IsBorrowed = false; 
//      BorrowedBy = None; 
//      BorrowDate = None; 
//     }

//    { Title = "1984"; 
//      Author = "George Orwell"; 
//      Genre = "Dystopian"; 
//      Status = "Available"; 
//      IsBorrowed = false; 
//      BorrowedBy = None; 
//      BorrowDate = None; 
//    }
   

//    { Title = "Moby Dick"; 
//      Author = "Herman Melville"; 
//      Genre = "Adventure"; 
//      Status = "Borrowed"; 
//      IsBorrowed = true; 
//      BorrowedBy = Some "John Doe"; 
//      BorrowDate = Some (DateTime.Now.AddDays(-10.0)); 
//    }
//]


