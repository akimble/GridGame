using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace GridGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const int _NUMROWS = 3;
        private const int _NUMCOLS = 3;
        private const int _NUMTILES = _NUMROWS * _NUMCOLS;

        private GridTile[] _board;
        private int _firstSelectedTileIndex;
        private GridTile _firstSelectedTile;
        private List<GridTile> highlightedTiles;

        public MainWindow()
        {
            InitializeComponent();

            _board = new GridTile[_NUMTILES];
            _firstSelectedTileIndex = -1;

            // Initialize the grid tiles
            for (int i = 0; i < _NUMTILES; i++)
            {
                int index;

                // Do not close over the loop variable
                index = i;

                if (i == 1)
                {
                    _board[i] = new GridTile(new Alpha());
                    Grid.SetRow(_board[i], 0);
                    Grid.SetColumn(_board[i], 1);
                }
                else if (i == 7)
                {
                    _board[i] = new GridTile(new Beta());
                    Grid.SetRow(_board[i], 2);
                    Grid.SetColumn(_board[i], 1);
                }
                else
                {
                    _board[i] = new GridTile();
                    Grid.SetRow(_board[i], i / 3);
                    Grid.SetColumn(_board[i], i % 3);
                }

                boardGrid.Children.Add(_board[i]);

                // Have each tile subscribe to a click event
                _board[i].Click += (sender, args) => GridTileClick(_board[index], index);
            }
        }

        /// <summary>
        /// Move the first selected tile's piece to the second selected tile if it is unoccupied.
        /// Otherwise, try to move this tile's piece to the first selected tile
        /// </summary>
        /// <param name="gridTile"></param>
        /// <param name="i"></param>
        private void GridTileClick(GridTile gridTile, int i)
        {
            // If no tile was previously selected, assign this tile as the selected tile (if it has a piece).
            // Otherwise, try to move this tile's piece to the first selected tile.
            if (_firstSelectedTileIndex == -1 && gridTile.OccupyingPiece != null)
            {
                _firstSelectedTileIndex = i;
                _firstSelectedTile = gridTile;

                // Give visual feedback that this tile is currently selected
                gridTile.BorderThickness = new Thickness(3);
                gridTile.BorderBrush = System.Windows.Media.Brushes.Red;

                highlightedTiles = HighlightAvailableMoves(_firstSelectedTile, _firstSelectedTileIndex);
            }
            else if (_firstSelectedTileIndex != -1)
            {
                // If the first tile is not reselected, proceed
                if (_firstSelectedTileIndex != i)
                {
                    // If the second tile is not occupied and it's highlighted, move the first tile's piece to the second tile
                    if (gridTile.OccupyingPiece == null && highlightedTiles.Contains(gridTile))
                    {
                        // "Move" the first selected tile's piece to the second selected tile
                        gridTile.OccupyingPiece = _firstSelectedTile.OccupyingPiece;
                        _firstSelectedTile.OccupyingPiece = null;

                        // "Refresh" the tile contents to show their piece's image or show nothing if the tile has no piece
                        gridTile.Content = gridTile.OccupyingPiece.PieceImage;
                        _firstSelectedTile.Content = null;
                    }
                    // If the second tile IS occupied, have the first piece attack the second piece
                    else if (gridTile.OccupyingPiece != null)
                    {
                        gridTile.OccupyingPiece.Hp = CalculateHPAfterAttacked(_firstSelectedTile.OccupyingPiece.Atk, gridTile.OccupyingPiece.Hp, gridTile.OccupyingPiece.Def);

                        // Remove the defending piece if it is defeated
                        if (gridTile.OccupyingPiece.Hp <= 0)
                        {
                            gridTile.OccupyingPiece = null;
                            gridTile.Content = null;
                        }
                    }
                }

                UnhighlightAvailableMoves(highlightedTiles);

                // Reset the tile to its default, unselected look
                _firstSelectedTile.BorderThickness = new Thickness(1);
                _firstSelectedTile.BorderBrush = System.Windows.Media.Brushes.Black;

                // Reset the selectedFileIndex and remove the reference to the previous gridTile
                _firstSelectedTileIndex = -1;
                _firstSelectedTile = null;
            }
        }

        /// <summary>
        /// Give thick, yellow borders to available tiles based on how many tiles the piece can move to
        /// </summary>
        /// <param name="gridTile"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        private List<GridTile> HighlightAvailableMoves(GridTile gridTile, int index)
        {
            List<GridTile> availableTiles;
            int minColIndex, maxColIndex, minRowIndex, maxRowIndex, tempMoveNum, potentialTileIndex;
            bool leftAvailable, rightAvailable, upAvailable, downAvailable;

            availableTiles = new List<GridTile>();
            minColIndex = index - (index % _NUMCOLS);
            maxColIndex = index + (_NUMCOLS - (index % _NUMCOLS)) - 1;
            minRowIndex = index % _NUMROWS;
            maxRowIndex = _NUMTILES - (_NUMROWS - minRowIndex);

            // LEFT ---------------------------------------------------
            tempMoveNum = 1;
            potentialTileIndex = index - tempMoveNum;
            leftAvailable = potentialTileIndex >= minColIndex && _board[potentialTileIndex].OccupyingPiece == null;

            while (leftAvailable && tempMoveNum <= gridTile.OccupyingPiece.MoveRange)
            {
                availableTiles.Add(_board[potentialTileIndex]);

                tempMoveNum++;
                potentialTileIndex = index - tempMoveNum;

                leftAvailable = potentialTileIndex >= minColIndex && _board[potentialTileIndex].OccupyingPiece == null;
            }

            // RIGHT --------------------------------------------------
            tempMoveNum = 1;
            potentialTileIndex = index + tempMoveNum;
            rightAvailable = potentialTileIndex <= maxColIndex && _board[potentialTileIndex].OccupyingPiece == null;

            while (rightAvailable && tempMoveNum <= gridTile.OccupyingPiece.MoveRange)
            {
                availableTiles.Add(_board[potentialTileIndex]);

                tempMoveNum++;
                potentialTileIndex = index + tempMoveNum;

                rightAvailable = potentialTileIndex <= maxColIndex && _board[potentialTileIndex].OccupyingPiece == null;
            }

            // UP -----------------------------------------------------
            tempMoveNum = 1;
            potentialTileIndex = index - _NUMCOLS;
            upAvailable = potentialTileIndex >= minRowIndex && _board[potentialTileIndex].OccupyingPiece == null;

            while (upAvailable && tempMoveNum <= gridTile.OccupyingPiece.MoveRange)
            {
                availableTiles.Add(_board[potentialTileIndex]);

                tempMoveNum++;
                potentialTileIndex = index - tempMoveNum * _NUMCOLS;

                upAvailable = potentialTileIndex >= minRowIndex && _board[potentialTileIndex].OccupyingPiece == null;
            }

            // DOWN ---------------------------------------------------
            tempMoveNum = 1;
            potentialTileIndex = index + _NUMCOLS;
            downAvailable = potentialTileIndex <= maxRowIndex && _board[potentialTileIndex].OccupyingPiece == null;

            while (downAvailable && tempMoveNum <= gridTile.OccupyingPiece.MoveRange)
            {
                availableTiles.Add(_board[potentialTileIndex]);

                tempMoveNum++;
                potentialTileIndex = index + tempMoveNum * _NUMCOLS;

                downAvailable = potentialTileIndex <= maxRowIndex && _board[potentialTileIndex].OccupyingPiece == null;
            }

            // --------------------------------------------------------
            // Apply a thick, yellow border around all legal moves for the piece
            foreach (GridTile tile in availableTiles)
            {
                tile.BorderThickness = new Thickness(3);
                tile.BorderBrush = System.Windows.Media.Brushes.Yellow;
            }

            return availableTiles;
        }

        /// <summary>
        /// Remove the highlight from all previously highlighted tiles
        /// </summary>
        /// <param name="highlightedTiles"></param>
        private void UnhighlightAvailableMoves(List<GridTile> highlightedTiles)
        {
            foreach (GridTile tile in highlightedTiles)
            {
                tile.BorderThickness = new Thickness(1);
                tile.BorderBrush = System.Windows.Media.Brushes.Black;
            }
        }

        /// <summary>
        /// Return the defender's HP after being attacked
        /// </summary>
        /// <param name="attacker_atk"></param>
        /// <param name="defender_hp"></param>
        /// <param name="defender_def"></param>
        /// <returns></returns>
        private int CalculateHPAfterAttacked(int attacker_atk, int defender_hp, int defender_def)
        {
            int dmg, res;

            // If attacker_atk is <= defender_def, subtract only 1 HP
            dmg = attacker_atk - defender_def;
            res = defender_hp - (dmg > 1 ? dmg : 1);

            return res;
        }
    }
}
