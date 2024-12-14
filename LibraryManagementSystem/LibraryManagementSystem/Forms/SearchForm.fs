namespace Forms

open System.Windows.Forms
open System
open System.Drawing
open CoreFunctions // Import CoreFunctions to access searchBooksByTitle

module SearchForms =

    // Define the Book record type explicitly (optional here, but for clarity)
    type Book = { Title: string; Author: string; Genre: string; Status: string; IsBorrowed: bool; BorrowedBy: string option; BorrowDate: DateTime option }

    type SearchForm(searchedBookTitle: string) as this =
        inherit Form()

        // Define UI components for showing book info
        let lblTitle = new Label(Top = 20, Left = 20, Width = 350, Font = new Font("", 10f))
        let lblAuthor = new Label(Top = 60, Left = 20, Width = 350, Font = new Font("", 10f))
        let lblGenre = new Label(Top = 100, Left = 20, Width = 350, Font = new Font("", 10f))
        let lblStatus = new Label(Top = 140, Left = 20, Width = 350, Font = new Font("", 10f))
        let lblBorrowedBy = new Label(Top = 180, Left = 20, Width = 350, Font = new Font("", 10f))
        let lblBorrowDate = new Label(Top = 220, Left = 20, Width = 350, Font = new Font("", 10f))
        let btnExit = new Button(Top = 380, Left = 20, Text = "Exit", Width = 100, Font = new Font("", 10f), BackColor = Color.DarkRed)

        do
            // UI Setup
            this.Text <- "Search Results"
            this.Width <- 650
            this.Height <- 500
            this.Controls.Add(lblTitle)
            this.Controls.Add(lblAuthor)
            this.Controls.Add(lblGenre)
            this.Controls.Add(lblStatus)
            this.Controls.Add(lblBorrowedBy)
            this.Controls.Add(lblBorrowDate)
            this.Controls.Add(btnExit)

            // Event handler for the Exit button
            btnExit.Click.Add(fun _ -> 
                this.Close() // Close the SearchForm when the button is clicked
            )

        // Populate the form with results
        let populateForm () =
            let searchResults = CoreFunctions.searchBooksByTitle searchedBookTitle // Call search from CoreFunctions
            if List.isEmpty searchResults then
                lblTitle.Text <- "No book with this name in the library."
                lblAuthor.Text <- ""
                lblGenre.Text <- ""
                lblStatus.Text <- ""
                lblBorrowedBy.Text <- ""
                lblBorrowDate.Text <- ""
            else
                let book = searchResults.[0] // Get the first result (assuming unique titles)
                lblTitle.Text <- "Title: " + book.Title // Use '+' for concatenation
                lblAuthor.Text <- "Author: " + book.Author
                lblGenre.Text <- "Genre: " + book.Genre
                lblStatus.Text <- "Status: " + book.Status
                lblBorrowedBy.Text <- "Borrowed By: " + (book.BorrowedBy |> Option.defaultValue "N/A")
                lblBorrowDate.Text <- "Borrow Date: " + (book.BorrowDate |> Option.map (fun date -> date.ToString("yyyy-MM-dd")) |> Option.defaultValue "N/A")

        // Call populateForm to show results
        do populateForm()
