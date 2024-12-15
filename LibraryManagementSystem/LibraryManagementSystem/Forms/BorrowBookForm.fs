module BorrowBookForm

open System
open System.Drawing
open System.Windows.Forms
open BookData
open CoreFunctions

type BorrowBookForm() as this =
    inherit Form()

    // Define UI components with updated design
    let titleLabel = new Label(Text = "Book Title:", Location = Point(30, 30), Font = new Font("Arial", 12.0f))
    let titleBox = new TextBox(Location = Point(150, 30), Width = 300, Font = new Font("Arial", 12.0f))

    let userIdLabel = new Label(Text = "User ID:", Location = Point(30, 80), Font = new Font("Arial", 12.0f))
    let userIdBox = new TextBox(Location = Point(150, 80), Width = 300, Font = new Font("Arial", 12.0f))

    let borrowButton = new Button(
        Text = "Borrow", 
        Location = Point(150, 140), 
        Width = 140, 
        Height = 50, 
        BackColor = Color.MediumSeaGreen, 
        ForeColor = Color.White,
        Font = new Font("Arial", 12.0f, FontStyle.Bold)
    )

    let cancelButton = new Button(
        Text = "Cancel", 
        Location = Point(310, 140), 
        Width = 140, 
        Height = 50, 
        BackColor = Color.DarkRed, 
        ForeColor = Color.White,
        Font = new Font("Arial", 12.0f, FontStyle.Bold)
    )

    do
        // Initialize form properties
        this.Text <- "Borrow Book"
        this.Size <- Size(520, 250)
        this.StartPosition <- FormStartPosition.CenterScreen
        this.BackColor <- Color.WhiteSmoke

        // Add components to the form
        this.Controls.AddRange([| titleLabel; titleBox; userIdLabel; userIdBox; borrowButton; cancelButton |])

        // Event handler for Borrow button
        borrowButton.Click.Add(fun _ ->
            let title = titleBox.Text.Trim()
            let userId = userIdBox.Text.Trim()

            if String.IsNullOrWhiteSpace(title) || String.IsNullOrWhiteSpace(userId) then
                MessageBox.Show("Both fields are required!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error) |> ignore
            else
                let normalizedTitle = title.ToLower()
                match borrowBook title userId with
                | Result.Ok successMessage ->
                    MessageBox.Show(successMessage, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information) |> ignore
                    this.Close() // Close the form after successful borrowing
                | Result.Error errorMessage ->
                    MessageBox.Show(errorMessage, "Borrow Error", MessageBoxButtons.OK, MessageBoxIcon.Error) |> ignore
        )

        // Event handler for Cancel button
        cancelButton.Click.Add(fun _ -> this.Close())
