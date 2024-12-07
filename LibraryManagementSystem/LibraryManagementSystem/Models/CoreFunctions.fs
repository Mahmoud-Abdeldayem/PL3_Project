module CoreFunctions

open BookData

/// Function to add a book to the library
//if the book title is already added it will be handeled with the GUI with an error message, else it will add to the record
let addBook title author genre =
    if booksMap.ContainsKey(title) then
        printfn "Book with the title '%s' already exists." title
    else
        let newBook = {
            Title = title
            Author = author
            Genre = genre
            Status = "Available"
        }
        booksMap <- booksMap.Add(title, newBook)
        printfn "Book '%s' added successfully!" title


