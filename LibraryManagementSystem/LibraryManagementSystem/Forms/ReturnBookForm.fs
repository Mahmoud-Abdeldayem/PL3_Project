namespace Forms

open System
open System.Drawing
open System.Windows.Forms
open CoreFunctions
open BookData

module ReturnBookForm =
    type ReturnBookForm() as this =
        inherit Form()

        // Define UI components to match BorrowBookForm style
        let titleLabel = new Label(
            Text = "Book Title:",
            Location = Point(30, 30),
            Font = new Font("Arial", 12.0f)
        )
        
        let titleBox = new TextBox(
            Location = Point(150, 30),
            Width = 300,
            Font = new Font("Arial", 12.0f)
        )

        let returnButton = new Button(
            Text = "Return",
            Location = Point(150, 100),
            Width = 140,
            Height = 50,
            BackColor = Color.MediumSeaGreen,
            ForeColor = Color.White,
            Font = new Font("Arial", 12.0f, FontStyle.Bold)
        )

        let cancelButton = new Button(
            Text = "Cancel",
            Location = Point(310, 100),
            Width = 140,
            Height = 50,
            BackColor = Color.DarkRed,
            ForeColor = Color.White,
            Font = new Font("Arial", 12.0f, FontStyle.Bold)
        )

        do
            // Initialize form properties
            this.Text <- "Return Book"
            this.Size <- Size(520, 250)
            this.StartPosition <- FormStartPosition.CenterScreen
            this.BackColor <- Color.WhiteSmoke

            // Add components to the form
            this.Controls.AddRange([| titleLabel; titleBox; returnButton; cancelButton |])

            // Event handler for Return button
            returnButton.Click.Add(fun _ ->
                let title = titleBox.Text.Trim()

                if String.IsNullOrWhiteSpace(title) then
                    MessageBox.Show("Please enter a book title.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error) |> ignore
                else
                    match returnBookByTitle title with
                    | Result.Ok successMessage ->
                        MessageBox.Show(successMessage, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information) |> ignore
                        this.Close() // Close the form after successful returning
                    | Result.Error errorMessage ->
                        MessageBox.Show(errorMessage, "Return Error", MessageBoxButtons.OK, MessageBoxIcon.Error) |> ignore
            )

            // Event handler for Cancel button
            cancelButton.Click.Add(fun _ -> this.Close())
