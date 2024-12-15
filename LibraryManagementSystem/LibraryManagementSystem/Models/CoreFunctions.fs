module CoreFunctions

open BookData
open System
open System.Threading
open System.Reflection.Emit
open System.Drawing

/// Function to add a book to the library
let addBook title author genre =
    if booksMap.ContainsKey(title) then
        printfn "Book with the title '%s' already exists." title
    else
        let newBook = {
            Title = title
            Author = author
            Genre = genre
            Status = "Available"
            IsBorrowed = false
            BorrowedBy = None
            BorrowDate = None
        }
        booksMap <- booksMap.Add(title, newBook)
        printfn "Book '%s' added successfully!" title



/// Function to borrow a book
let borrowBook (title: string) (userId: string) : Result<string, string> =
    let normalizedTitle = title.ToLower()

    match booksMap.TryFind(normalizedTitle) with
    | Some book when book.IsBorrowed -> 
        // The book is already borrowed
        Result.Error (sprintf "Book '%s' is already borrowed." title)
    | Some book ->
        // Proceed with borrowing the book
        let updatedBook = 
            { book with 
                Status = "Borrowed"
                IsBorrowed = true
                BorrowedBy = Some userId
                BorrowDate = Some DateTime.Now
            }
        booksMap <- booksMap.Add(normalizedTitle, updatedBook)

        // Return success result
        Result.Ok (sprintf "Book '%s' borrowed successfully by user '%s'!" book.Title userId)
    | None -> 
        // Book not found in the library
        Result.Error (sprintf "Book '%s' not found in the library." title)



/// Function to return a borrowed book by its title
let returnBookByTitle (title: string) : Result<string, string> =
    let normalizedTitle = title.ToLower()

    // Check if the book is borrowed in the booksMap
    match booksMap.TryFind(normalizedTitle) with
    | Some book when book.IsBorrowed -> 
        // The book is borrowed, return it
        let updatedBook = 
            { book with 
                IsBorrowed = false
                BorrowedBy = None
                BorrowDate = None
                Status = "Available"
            }
        booksMap <- booksMap.Add(normalizedTitle, updatedBook)
        
        // Return success result
        Result.Ok (sprintf "Book '%s' has been returned successfully!" title)
    
    | Some book ->
        // The book is not borrowed
        Result.Error (sprintf "Book '%s' is not currently borrowed." title)

    | None ->
        // The book was not found
        Result.Error (sprintf "Book '%s' not found in the library." title)




/// Search for books by title in the booksMap
let searchBooksByTitle (title: string) =
    booksMap
    |> Map.toSeq // Convert the map to a sequence of key-value pairs
    |> Seq.map snd // Extract the `Book` values (ignore the keys)
    |> Seq.filter (fun book -> book.Title.Contains(title, StringComparison.OrdinalIgnoreCase)) // Search by title
    |> Seq.toList // Convert the sequence back to a list for further use

    




/// Function to retrieve book data as a list of tuples (Title, Author, Genre, Availability)
let getAllBooksWithAvailability () =
    booksMap
    |> Seq.map (fun kvp -> 
        let book = kvp.Value
        let availability = if book.IsBorrowed then "Borrowed" else "Available"
        (book.Title, book.Author, book.Genre, availability))
    |> Seq.toList
