module Forms.AddBookForm


open System
open System.Drawing
open System.Windows.Forms
open BookData
open CoreFunctions

type AddBookForm() as this =
    inherit Form()
    // create the input fields and buttons
    let titleLabel = new Label(Text = "Title:", Location = Point(10, 20))
    let titleBox = new TextBox(Location = Point(70, 20), Width = 300, Height = 30, Multiline = false)

    let authorLabel = new Label(Text = "Author:", Location = Point(10, 60))
    let authorBox = new TextBox(Location = Point(70, 60), Width = 300, Height = 30, Multiline = false)

    let genreLabel = new Label(Text = "Genre:", Location = Point(10, 100))
    let genreBox = new TextBox(Location = Point(70, 100), Width = 300, Height = 30, Multiline = false)

    let addButton = new Button(Text = "Add", Location = Point(150, 150), Width = 100, BackColor = Color.LightGreen)
    let cancelButton = new Button(Text = "Cancel", Location = Point(270, 150), Width = 100, BackColor = Color.LightCoral)

    do
        this.Text <- "Add New Book"
        this.Size <- Size(400, 250)
        this.StartPosition <- FormStartPosition.CenterScreen
        this.Controls.AddRange([| titleLabel; titleBox; authorLabel; authorBox; genreLabel; genreBox; addButton; cancelButton |])

        // Event handler for Add button
        //takes the input and store them in variables
        addButton.Click.Add(fun _ ->
            let title = titleBox.Text
            let author = authorBox.Text
            let genre = genreBox.Text

            // if the user did not enter any field will send an error
            if String.IsNullOrWhiteSpace(title) || String.IsNullOrWhiteSpace(author) || String.IsNullOrWhiteSpace(genre) then
                MessageBox.Show("All fields are required!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error) |> ignore

            // if the title already exists
            elif booksMap.ContainsKey(title) then
                MessageBox.Show($"A book with the title '{title}' already exists!", "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning) |> ignore  
                
            // add the book if there is no erros by sending the input to the function parameters and sending success message and close the form 
            else
                addBook title author genre
                MessageBox.Show("Book added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information) |> ignore
                this.Close()
        )

        // Event handler for Cancel button
        cancelButton.Click.Add(fun _ -> this.Close())

