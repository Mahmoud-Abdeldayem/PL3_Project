open System.Windows.Forms;
open System;
open Microsoft.FSharp.Linq;
open Forms.MainForm; 
open Forms.ShowBooksForm;

[<EntryPoint>]
let main argv =
    Application.Run(MainForm())
    0

    