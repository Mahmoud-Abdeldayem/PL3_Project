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
