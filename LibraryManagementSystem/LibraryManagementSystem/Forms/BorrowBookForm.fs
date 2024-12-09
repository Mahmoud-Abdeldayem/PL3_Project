module BorrowedBookForm

open System
open System.Drawing
open System.Windows.Forms
open BookData
open CoreFunctions

type BorrowBookForm() as this =
    inherit Form()

    // Create the input fields and buttons
    let titleLabel = new Label(Text = "Book Title:", Location = Point(10, 20))
    let titleBox = new TextBox(Location = Point(100, 20), Width = 300, Height = 30, Multiline = false)

    let userIdLabel = new Label(Text = "User ID:", Location = Point(10, 60))
    let userIdBox = new TextBox(Location = Point(100, 60), Width = 300, Height = 30, Multiline = false)

    let borrowButton = new Button(Text = "Borrow", Location = Point(150, 100), Width = 100, BackColor = Color.LightBlue)
    let cancelButton = new Button(Text = "Cancel", Location = Point(270, 100), Width = 100, BackColor = Color.LightCoral)

    do
        // Initialize form properties
        this.Text <- "Borrow Book"
        this.Size <- Size(450, 200)
        this.StartPosition <- FormStartPosition.CenterScreen
        this.Controls.AddRange([| titleLabel; titleBox; userIdLabel; userIdBox; borrowButton; cancelButton |])

        // Event handler for Borrow button
        borrowButton.Click.Add(fun _ ->
            let title = titleBox.Text
            let userId = userIdBox.Text

            // Check if the title or user ID is empty
            if String.IsNullOrWhiteSpace(title) || String.IsNullOrWhiteSpace(userId) then
                MessageBox.Show("Both fields are required!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error) |> ignore
            else
                // Normalize title to handle case insensitivity
                let normalizedTitle = title.ToLower()

                // Call the borrowBook function and handle the result
                match borrowBook title userId with
                | Result.Ok successMessage ->
                    // Book borrowed successfully
                    MessageBox.Show(successMessage, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information) |> ignore
                    this.Close()  // Close the form after successful borrowing
                | Result.Error errorMessage ->
                    // Handle the error case
                    MessageBox.Show(errorMessage, "Borrow Error", MessageBoxButtons.OK, MessageBoxIcon.Error) |> ignore
        )

        // Event handler for Cancel button
        cancelButton.Click.Add(fun _ -> this.Close())
