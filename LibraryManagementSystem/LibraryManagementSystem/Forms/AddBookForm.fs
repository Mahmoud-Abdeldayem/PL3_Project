module Forms.AddBookForm

open System
open System.Drawing
open System.Windows.Forms
open BookData
open CoreFunctions

type AddBookForm() as this =
    inherit Form()

    // Define UI components with updated design
    let titleLabel = new Label(Text = "Book Title:", Location = Point(30, 30), Font = new Font("Arial", 12.0f))
    let titleBox = new TextBox(Location = Point(150, 30), Width = 300, Font = new Font("Arial", 12.0f))

    let authorLabel = new Label(Text = "Author:", Location = Point(30, 80), Font = new Font("Arial", 12.0f))
    let authorBox = new TextBox(Location = Point(150, 80), Width = 300, Font = new Font("Arial", 12.0f))

    let genreLabel = new Label(Text = "Genre:", Location = Point(30, 130), Font = new Font("Arial", 12.0f))
    let genreBox = new TextBox(Location = Point(150, 130), Width = 300, Font = new Font("Arial", 12.0f))

    let addButton = new Button(
        Text = "Add Book", 
        Location = Point(150, 200), 
        Width = 140, 
        Height = 50, 
        BackColor = Color.MediumSeaGreen, 
        ForeColor = Color.White,
        Font = new Font("Arial", 12.0f, FontStyle.Bold)
    )

    let cancelButton = new Button(
        Text = "Cancel", 
        Location = Point(310, 200), 
        Width = 140, 
        Height = 50, 
        BackColor = Color.DarkRed, 
        ForeColor = Color.White,
        Font = new Font("Arial", 12.0f, FontStyle.Bold)
    )

    do
        // Set up form properties
        this.Text <- "Add New Book"
        this.Size <- Size(500, 320)
        this.StartPosition <- FormStartPosition.CenterScreen
        this.BackColor <- Color.WhiteSmoke

        // Add components to the form
        this.Controls.AddRange([| titleLabel; titleBox; authorLabel; authorBox; genreLabel; genreBox; addButton; cancelButton |])

        // Event handler for Add button
        addButton.Click.Add(fun _ ->
            let title = titleBox.Text.Trim()
            let author = authorBox.Text.Trim()
            let genre = genreBox.Text.Trim()

            if String.IsNullOrWhiteSpace(title) || String.IsNullOrWhiteSpace(author) || String.IsNullOrWhiteSpace(genre) then
                MessageBox.Show("All fields are required!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error) |> ignore
            elif booksMap.ContainsKey(title) then
                MessageBox.Show($"A book with the title '{title}' already exists!", "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning) |> ignore
            else
                addBook title author genre
                MessageBox.Show("Book added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information) |> ignore
                this.Close()
        )

        // Event handler for Cancel button
        cancelButton.Click.Add(fun _ -> this.Close())
