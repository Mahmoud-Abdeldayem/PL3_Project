namespace Forms

open System.Windows.Forms
open System
open System.Drawing
open CoreFunctions // Import CoreFunctions to access searchBooksByTitle


module SearchForms =

    type SearchForm(searchedBookTitle: string) as this =
        inherit Form()

        // UI components for showing book info
        let lblTitle = new Label(Top = 20, Left = 20, Width = 350)
        let lblAuthor = new Label(Top = 60, Left = 20, Width = 350)
        let lblGenre = new Label(Top = 100, Left = 20, Width = 350)
        let lblStatus = new Label(Top = 140, Left = 20, Width = 350)
        let lblBorrowedBy = new Label(Top = 180, Left = 20, Width = 350)
        let lblBorrowDate = new Label(Top = 220, Left = 20, Width = 350)
        let btnExit = new Button(Top = 380, Left = 20, Text = "Exit", Width = 100, BackColor = Color.DarkRed)

        do
            // UI setup
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

            // Exit button event
            btnExit.Click.Add(fun _ -> this.Close())

        // Populate the form with search results
        let populateForm () =
            let searchResults = searchBooksByTitle searchedBookTitle // Use the updated function
            if List.isEmpty searchResults then
                // Handle case where no books are found
                lblTitle.Text <- "No books found with this title."
                lblAuthor.Text <- ""
                lblGenre.Text <- ""
                lblStatus.Text <- ""
                lblBorrowedBy.Text <- ""
                lblBorrowDate.Text <- ""
            else
                // Display the first match (or adjust logic for multiple results if needed)
                let book = searchResults.Head
                lblTitle.Text <- "Title: " + book.Title
                lblAuthor.Text <- "Author: " + book.Author
                lblGenre.Text <- "Genre: " + book.Genre
                lblStatus.Text <- "Status: " + book.Status
                lblBorrowedBy.Text <- "Borrowed By: " + (book.BorrowedBy |> Option.defaultValue "N/A")
                lblBorrowDate.Text <- "Borrow Date: " + (book.BorrowDate |> Option.map (fun date -> date.ToString("yyyy-MM-dd")) |> Option.defaultValue "N/A")

        // Call populateForm on initialization
        do populateForm()

