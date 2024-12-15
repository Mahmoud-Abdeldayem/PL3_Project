namespace Forms

open System
open System.Drawing
open System.Windows.Forms
open CoreFunctions

module SearchForms =

    type SearchForm(searchedBookTitle: string) as this =
        inherit Form()

        // Define UI components with updated layout and design
        let lblTitle = new Label(Top = 30, Left = 20, Width = 600, Font = new Font("Segoe UI", 14.0f, FontStyle.Bold), ForeColor = Color.FromArgb(50, 50, 50))
        let lblAuthor = new Label(Top = 80, Left = 20, Width = 600, Font = new Font("Segoe UI", 12.0f), ForeColor = Color.FromArgb(100, 100, 100))
        let lblGenre = new Label(Top = 120, Left = 20, Width = 600, Font = new Font("Segoe UI", 12.0f), ForeColor = Color.FromArgb(100, 100, 100))
        let lblStatus = new Label(Top = 160, Left = 20, Width = 600, Font = new Font("Segoe UI", 12.0f), ForeColor = Color.FromArgb(100, 100, 100))
        let lblBorrowedBy = new Label(Top = 200, Left = 20, Width = 600, Font = new Font("Segoe UI", 12.0f), ForeColor = Color.FromArgb(100, 100, 100))
        let lblBorrowDate = new Label(Top = 240, Left = 20, Width = 600, Font = new Font("Segoe UI", 12.0f), ForeColor = Color.FromArgb(100, 100, 100))

        let btnExit = new Button(
            Text = "Exit", 
            Top = 320, 
            Left = 250, 
            Width = 150, 
            Height = 50, 
            BackColor = Color.FromArgb(30, 144, 255), 
            ForeColor = Color.White, 
            Font = new Font("Segoe UI", 12.0f, FontStyle.Bold), 
            FlatStyle = FlatStyle.Flat
        )

        do
            // Form properties
            this.Text <- "Search Results"
            this.Size <- Size(650, 420)
            this.StartPosition <- FormStartPosition.CenterScreen
            this.BackColor <- Color.White

            // Add shadow effect to the form
            this.FormBorderStyle <- FormBorderStyle.FixedDialog
            this.MaximizeBox <- false
            this.Padding <- Padding(10)
            this.BackColor <- Color.FromArgb(245, 245, 245)
            this.Opacity <- 0.98

            // Add components to the form
            this.Controls.AddRange([| lblTitle; lblAuthor; lblGenre; lblStatus; lblBorrowedBy; lblBorrowDate; btnExit |])

            // Event handler for the Exit button
            btnExit.Click.Add(fun _ -> this.Close())

            // Button hover effects
            btnExit.MouseEnter.Add(fun _ -> btnExit.BackColor <- Color.FromArgb(70, 130, 180))
            btnExit.MouseLeave.Add(fun _ -> btnExit.BackColor <- Color.FromArgb(30, 144, 255))

        // Populate the form with search results
        let populateForm () =
            let searchResults = searchBooksByTitle searchedBookTitle // Use the updated function
            if List.isEmpty searchResults then
                // Case: No books found
                lblTitle.Text <- "No books found with the title: " + searchedBookTitle
                lblAuthor.Text <- "Try refining your search."
                lblGenre.Text <- ""
                lblStatus.Text <- ""
                lblBorrowedBy.Text <- ""
                lblBorrowDate.Text <- ""
            else
                // Case: Display the first match (or extend logic for multiple results)
                let book = searchResults.Head
                lblTitle.Text <- "Title: " + book.Title
                lblAuthor.Text <- "Author: " + book.Author
                lblGenre.Text <- "Genre: " + book.Genre
                lblStatus.Text <- "Status: " + book.Status
                lblBorrowedBy.Text <- "Borrowed By: " + (book.BorrowedBy |> Option.defaultValue "N/A")
                lblBorrowDate.Text <- "Borrow Date: " + (book.BorrowDate |> Option.map (fun date -> date.ToString("yyyy-MM-dd")) |> Option.defaultValue "N/A")

        // Populate the form during initialization
        do populateForm()
