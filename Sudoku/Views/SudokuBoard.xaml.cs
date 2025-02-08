using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku.Views;

public partial class SudokuBoard : ContentPage
{
    private int[,] board =
    {
        { 5, 1, 6, 0, 0, 3, 4, 2, 0 },
        { 7, 0, 0, 2, 0, 4, 0, 8, 0 },
        { 0, 2, 8, 5, 7, 0, 0, 0, 1 },
        { 1, 0, 0, 3, 6, 0, 0, 4, 0 },
        { 2, 3, 0, 0, 0, 0, 0, 7, 6 },
        { 0, 0, 0, 0, 9, 1, 3, 0, 0 },
        { 0, 4, 0, 0, 0, 7, 5, 6, 0 },
        { 3, 0, 1, 0, 0, 0, 2, 0, 0 },
        { 0, 8, 0, 0, 0, 9, 0, 0, 3 }
    };
    
    private int[,] boardSolution =
    {
        { 5, 1, 6, 9, 8, 3, 4, 2, 7 },
        { 7, 9, 3, 2, 1, 4, 6, 8, 5 },
        { 4, 2, 8, 5, 7, 6, 9, 3, 1 },
        { 1, 5, 7, 3, 6, 2, 8, 4, 9 },
        { 2, 3, 9, 8, 4, 5, 1, 7, 6 },
        { 8, 6, 4, 7, 9, 1, 3, 5, 2 },
        { 9, 4, 2, 1, 3, 7, 5, 6, 8 },
        { 3, 7, 1, 6, 5, 8, 2, 9, 4 },
        { 6, 8, 5, 4, 2, 9, 7, 1, 3 }
    };
    public SudokuBoard()
    {
        InitializeComponent();
        GenerateSudokuBoard();
    }

    void GenerateSudokuBoard()
    {
        for (int i = 0; i < 9; i++)
        {
            SudokuGrid.AddRowDefinition(new RowDefinition(GridLength.Star));
            SudokuGrid.AddColumnDefinition(new ColumnDefinition(GridLength.Star));
        }

        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                Entry entry = new Entry()
                { 
                    BackgroundColor = (i % 2 == 0 && j % 2 != 0) || (i % 2 != 0 && j % 2 == 0)? Colors.Lavender : Colors.White,
                    TextColor = Colors.Black,
                    FontSize = 20,
                    VerticalTextAlignment = TextAlignment.Center,
                    HorizontalTextAlignment = TextAlignment.Center,
                    Keyboard = Keyboard.Numeric,
                    Text = board[i, j].ToString() == "0" ? "" : board[i, j].ToString(),
                    IsEnabled = board[i, j].ToString() == "0",

                };
                
                entry.SetValue(Grid.RowProperty, i);
                entry.SetValue(Grid.ColumnProperty, j);

                entry.TextChanged += OnCellTextChange;
                SudokuGrid.AddWithSpan(entry, i, j);
            }
        }
    }

    void OnCellTextChange(object sender, TextChangedEventArgs e)
    {
        var location = (Entry)sender;

        if (!(string.IsNullOrEmpty(location.Text)) && (!int.TryParse(location.Text, out int value) || value < 1 || value > 9))
        {
            location.Text = "";
            
        }
    }

    private void BtnCheck_OnClicked(object? sender, EventArgs e)
    {
        
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                SudokuGrid.Children.OfType<Entry>().FirstOrDefault(e => e.)
            }
        }
    }
}