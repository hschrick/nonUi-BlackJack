using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackDebug
{
    class Program
    {

        private static string[] _cards = new string[]
        {

             "2H", "3H", "4H", "5H", "6H", "7H", "8H", "9H", "TH", "JH", "QH", "KH", "AH",
             "2D", "3D", "4D", "5D", "6D", "7D", "8D", "9D", "TD", "JD", "QD", "KD", "AD",
             "2C", "3C", "4C", "5C", "6C", "7C", "8C", "9C", "TC", "JC", "QC", "KC", "AC",
             "2S", "3S", "4S", "5S", "6S", "7S", "8S", "9S", "TS", "JS", "QS", "KS", "AS"
        };

        //our randomized array deck
        private static string[] _deckArr = new string[_cards.Length];
        //our shuffled deck implemented into a list
        private static List<string> deck = new List<string>(_deckArr.Length);

        //Player/Dealer points
        private static int _playerVal;
        private static int _dealerVal;

        //Player/Dealer card strands
        private static string _pCStrand;
        private static string _dCStrand;

        //Player/ Dealer economy
        private static double _pMoney = 100;
        private static double _pBet;
        private static double _dMoney = 200;

        //Win count
        private static int _winCount;
        private static int _lossCount;
        private static int _tieCount;

        private static string _user;
        private static string _dealer;
        private static string _XX;



        static void Main(string[] args)
        {
            //randomize our cards into a deck array
            Shuffle();
            //start game
            FirstHand();

            Console.ReadLine();
        }

        static void FirstHand()
        {
           

            Console.WriteLine("========== New Game ============");
            Console.WriteLine("You have : $" + _pMoney);
            Console.Write("How much do you bet : ");
            int bet = Convert.ToInt32(Console.ReadLine());

            while (bet > _pMoney)
            {
                Console.WriteLine("Not enough funds");
                Console.WriteLine("How much do you bet?");
                bet = Convert.ToInt32(Console.ReadLine());
            }
            while (_pMoney != 0 || _dMoney != 0)
            {
                //finalize the players bet
                _pBet = bet;
                Console.WriteLine("You bet $" + _pBet);
                //value update
                //player 1st card
                while (true)
                {
                    Console.Write("Input 1st card for customer (3H, AD, TC, etc. or XX to draw from deck) : ");
                    string ptemp = Console.ReadLine();
                    if(ptemp == "XX" || ptemp == "xx")
                    {
                        //deal the random card at the top of the deck and update players value
                        PlayerValueUpdate(deck[0]);
                        //append the card onto the users string of cards
                        _user = _user + " " + deck[0];
                        //remove the card from the deck
                        deck.RemoveAt(0);
                        break;
                    }
                    if (deck.Contains(ptemp) || deck.Contains(ptemp.ToUpper().ToString()))
                    {
                        PlayerValueUpdate(ptemp.ToUpper());
                        _user = _user + " " + ptemp;
                        deck.Remove(ptemp.ToUpper());
                        break;
                    }
                    else
                    {
                        Console.WriteLine(" === ERROR === The card you selected is not in the deck");
                    }
                }
                //Dealer 1st card
                while (true)
                {
                    Console.Write("Input 1st card for Dealer (3H, AD, TC, etc. or XX to draw from deck) : ");
                    string dtemp = Console.ReadLine();
                    if (dtemp == "XX" || dtemp == "xx")
                    {
                        //deal the random card at the top of the deck and update players value
                        DealerValueUpdate(deck[0]);
                        //append the card onto the users string of cards
                        _dealer = _dealer + " " + deck[0];
                        //remove the card from the deck
                        deck.RemoveAt(0);
                        break;
                    }
                    if (deck.Contains(dtemp) || deck.Contains(dtemp.ToUpper().ToString()))
                    {
                        DealerValueUpdate(dtemp.ToUpper());
                        _dealer = _dealer + " " + dtemp;
                        deck.Remove(dtemp.ToUpper());
                       
                        break;
                    }
                    else
                    {
                        Console.WriteLine(" === ERROR === The card you selected is not in the deck");
                    }
                }

                //player 2nd card
                while (true)
                {
                    Console.Write("Input 2nd card for customer (3H, AD, TC, etc. or XX to draw from deck) : ");
                    string ptemp = Console.ReadLine();
                    if (ptemp == "XX" || ptemp == "xx")
                    {
                        //deal the random card at the top of the deck and update players value
                        PlayerValueUpdate(deck[0]);
                        //append the card onto the users string of cards
                        _user = _user + " " + deck[0];
                        //remove the card from the deck
                        deck.RemoveAt(0);
                        break;
                    }
                    if (deck.Contains(ptemp) || deck.Contains(ptemp.ToUpper().ToString()))
                    {
                        PlayerValueUpdate(ptemp.ToUpper());
                        _user = _user + " "+ ptemp;
                        deck.Remove(ptemp.ToUpper());
                        break;
                    }
                    else
                    {
                        Console.WriteLine(" === ERROR === The card you selected is not in the deck");
                    }
                }
                //Dealer 2nd card
                while (true)
                {
                    Console.Write("Input 2nd card for Dealer (3H, AD, TC, etc. or XX to draw from deck) : ");
                    string dtemp = Console.ReadLine();
                    if (dtemp == "XX" || dtemp == "xx")
                    {
                        //deal the random card at the top of the deck and update players value
                        DealerValueUpdate(deck[0]);
                        //append the card onto the users string of cards
                        _dealer = _dealer + " " + deck[0];
                        //remove the card from the deck
                        deck.RemoveAt(0);
                        break;
                    }
                    if (deck.Contains(dtemp) || deck.Contains(dtemp.ToUpper().ToString()))
                    {
                        DealerValueUpdate(dtemp.ToUpper());
                        _XX = dtemp;
                        deck.Remove(dtemp.ToUpper());
                        break;
                    }
                    else
                    {
                        Console.WriteLine(" === ERROR === The card you selected is not in the deck");
                    }
                }

                Console.WriteLine("Your hand = " + _user + ", Hand Value = " + _playerVal);
                Console.WriteLine("Dealers hand = " + _dealer + " XX");
                _dealer = _dealer + " " + _XX;








                //Player Choice
                Console.Write("Do you want to surrender (Y or N) ? : ");
                string user = Console.ReadLine();
                if (user == "y" || user == "Y")
                {
                    Console.WriteLine("You surrender and lose half your bet");
                    _pBet = _pBet / 2;
                    _pMoney = _pMoney - _pBet;
                    _dMoney = _dMoney + _pBet;
                    PlayAgain();
                    break;
                }
                else if (user == "n" || user == "N")
                {
                    //If you obtained a blackjack in the begining
                    if(_playerVal == 21 && _dealerVal == 21)
                    {
                        WhoWins();
                        return;

                    }
                    if (_playerVal == 21 )
                    {
                        WinWithBlackJack();
                        return;
                    }
                    else
                    {
                        Play();
                        return;
                    }
                }
            }
        }


        static void Play()
        {
            Console.Write("Will you Hit or Stand (H or S) ? : ");
            string usr = Console.ReadLine();

            if (usr == "H" || usr == "h")
            {
                //you will enter the loop
            }
            if (usr == "S" || usr == "s")
            {
                //Call dealers turn
                DealerPlays();
                return;
            }
            while (_playerVal < 21)
            {
                Console.Write("Input next card for customer (3H, AD, TC, etc. or XX to draw from deck) : ");
                string ptemp = Console.ReadLine();
                if (ptemp == "XX" || ptemp == "xx")
                {
                    //deal the random card at the top of the deck and update players value
                    PlayerValueUpdate(deck[0]);
                    //append the card onto the users string of cards
                    _user = _user + " " + deck[0];
                    //remove the card from the deck
                    deck.RemoveAt(0);
                    
                }
                if (deck.Contains(ptemp) || deck.Contains(ptemp.ToUpper().ToString()))
                {
                    PlayerValueUpdate(ptemp.ToUpper());
                    _user = _user + " " + ptemp;
                    deck.Remove(ptemp.ToUpper());
                }
                else
                {
                    Console.WriteLine(" === ERROR === The card you selected is not in the deck");
                }
                Console.WriteLine("Your hand = " + _user + ", Hand Value = " + _playerVal);
                Console.Write("Will you Hit or Stand (H or S) ? : ");
                ptemp = Console.ReadLine();

                if(ptemp == "H" || ptemp == "h")
                {
                    //nothing happens the loop moves on
                }
                if (ptemp == "S" || ptemp == "s")
                {
                    //you break out of loop, Dealers turn
                    DealerPlays();
                    break;
                }
            }


        }


        static void DealerPlays()
        {
            

            while (_dealerVal < 17)
            {


                Console.Write("Input next card for Dealer (3H, AD, TC, etc. or XX to draw from deck) : ");
                string dtemp = Console.ReadLine();
                if (dtemp == "XX" || dtemp == "xx")
                {
                    //deal the random card at the top of the deck and update players value
                    DealerValueUpdate(deck[0]);
                    //append the card onto the users string of cards
                    _dealer = _dealer + " " + deck[0];
                    //remove the card from the deck
                    deck.RemoveAt(0);
                    
                }
                if (deck.Contains(dtemp) || deck.Contains(dtemp.ToUpper().ToString()))
                {
                    DealerValueUpdate(dtemp.ToUpper());
                    _dealer = _dealer + " " + dtemp;
                    deck.Remove(dtemp.ToUpper());
                    
                }
                else
                {
                    Console.WriteLine(" === ERROR === The card you selected is not in the deck");
                }


                Console.WriteLine("Dealer Hand = " + _dealer + ", Hand Value = " + _dealerVal);

                if (_dealerVal >= 17 && _dealerVal < 21)
                {
                    WhoWins();
                    return;
                }

                //if Dealers hand is greater than 21, call bust
                if (_dealerVal > 21)
                {
                    DealerBust();
                    return;
                }

                if (_dealerVal == 21)
                {
                    WhoWins();
                    return;
                }

                if (_dealerVal >= 17 && _dealerVal <= 21)
                {
                    WhoWins();
                    return;
                }
                //if dealer busts
                if (_dealerVal > 21)
                {
                    DealerBust();
                    return;
                }

                Console.Write("Will you Hit or Stand (H or S) ? : ");
                dtemp = Console.ReadLine();

                if (dtemp == "H" || dtemp == "h")
                {
                    //nothing happens the loop moves on
                }
               
            }




           // Console.WriteLine("Dealer hand = " + _dCStrand + ",Hand Value " + _dealerVal.ToString());






        



              
                

            
        }




        static void WinWithBlackJack()
        {
            if (_playerVal == 21)
            {
                _pMoney = _pMoney + (_pBet * 2.5);
                Console.WriteLine("You got a blackjack and won $" + (_pBet * 2.5) + " from Dealer");
                _dMoney = _dMoney - (_pBet * 2.5);
                _winCount++;
                PlayAgain();
                return;
            }

        }




        static void WhoWins()
        {
            if (_playerVal > _dealerVal && _playerVal < 21)
            {
                //deduct from dealers economy
                _dMoney = _dMoney - _pBet;
                //add to players economy
                _pMoney = _pMoney + _pBet;
                Console.WriteLine("You win, and got $" + _pBet + " from Dealer");
                _winCount++;
                PlayAgain();
                return;
            }
            if (_dealerVal > _playerVal && _dealerVal < 21)
            {
                //deduct from players economy
                _pMoney = _pMoney - _pBet;
                //add to dealers economy
                _dMoney = _dMoney + _pBet;
                Console.WriteLine("Dealer won, and got $" + _pBet + " from Player");
                _lossCount++;
                PlayAgain();
                return;
            }
            if (_dealerVal == 20 && _playerVal < 20)
            {
                //deduct from players economy
                _pMoney = _pMoney - _pBet;
                //add to dealers economy
                _dMoney = _dMoney + _pBet;
                Console.WriteLine("Dealer won, and got $" + _pBet + " from Player");
                _lossCount++;
                PlayAgain();
                return;
            }
            if (_dealerVal == 21 && _playerVal < 21)
            {
                //deduct from players economy
                _pMoney = _pMoney - _pBet;
                //add to dealers economy
                _dMoney = _dMoney + _pBet;
                Console.WriteLine("Dealer won, and got $" + _pBet + " from Player");
                _lossCount++;
                PlayAgain();
                return;
            }
            if (_playerVal == _dealerVal)
            {
                Console.WriteLine("Its a draw, nobody wins");
                _tieCount++;
                PlayAgain();
                return;
            }

            //send user back into game
            PlayAgain();
            return;
        }



        static void DealerBust()
        {
            //deduct from dealers economy
            _dMoney = _dMoney - _pBet;
            //add to players economy
            _pMoney = _pMoney + _pBet;
            Console.WriteLine("Dealer Bust");
            Console.WriteLine("Player Won and Got $" + _pBet + " from Dealer");
            _winCount++;
            PlayAgain();
        }

        static void PlayerBust()
        {
            //deduct from players economy
            _pMoney = _pMoney - _pBet;
            //add to dealers economy
            _dMoney = _dMoney + _pBet;
            Console.WriteLine("You Bust");
            Console.WriteLine("Dealer Won and Got $" + _pBet + " from User");
            _lossCount++;
            PlayAgain();
        }




        static void PlayerValueUpdate(string d)
        {
            if (d == "2H" || d == "2D" || d == "2S" || d == "2C" || d == "2h" || d == "2d" || d == "2s" || d == "2c")
            {
                _playerVal = _playerVal + 2;
                if (_playerVal > 21)
                {
                    if (_pCStrand.Contains("AH") || _pCStrand.Contains("AD") || _pCStrand.Contains("AS") || _pCStrand.Contains("AC"))
                    {
                        _playerVal = _playerVal - 10;
                    }
                }
            }
            if (d == "3H" || d == "3D" || d == "3S" || d == "3C")
            {
                _playerVal = _playerVal + 3;
                if (_playerVal > 21)
                {
                    if (_pCStrand.Contains("AH") || _pCStrand.Contains("AD") || _pCStrand.Contains("AS") || _pCStrand.Contains("AC"))
                    {
                        _playerVal = _playerVal - 10;
                    }
                }
            }
            if (d == "4H" || d == "4D" || d == "4S" || d == "4C")
            {
                _playerVal = _playerVal + 4;
                if (_playerVal > 21)
                {
                    if (_pCStrand.Contains("AH") || _pCStrand.Contains("AD") || _pCStrand.Contains("AS") || _pCStrand.Contains("AC"))
                    {
                        _playerVal = _playerVal - 10;
                    }
                }
            }
            if (d == "5H" || d == "5D" || d == "5S" || d == "5C")
            {
                _playerVal = _playerVal + 5;
                if (_playerVal > 21)
                {
                    if (_pCStrand.Contains("AH") || _pCStrand.Contains("AD") || _pCStrand.Contains("AS") || _pCStrand.Contains("AC"))
                    {
                        _playerVal = _playerVal - 10;
                    }
                }
            }
            if (d == "6H" || d == "6D" || d == "6S" || d == "6C")
            {
                _playerVal = _playerVal + 6;
                if (_playerVal > 21)
                {
                    if (_pCStrand.Contains("AH") || _pCStrand.Contains("AD") || _pCStrand.Contains("AS") || _pCStrand.Contains("AC"))
                    {
                        _playerVal = _playerVal - 10;
                    }
                }
            }
            if (d == "7H" || d == "7D" || d == "7S" || d == "7C")
            {
                _playerVal = _playerVal + 7;
                if (_playerVal > 21)
                {
                    if (_pCStrand.Contains("AH") || _pCStrand.Contains("AD") || _pCStrand.Contains("AS") || _pCStrand.Contains("AC"))
                    {
                        _playerVal = _playerVal - 10;
                    }
                }
            }
            if (d == "8H" || d == "8D" || d == "8S" || d == "8C")
            {
                _playerVal = _playerVal + 8;
                if (_playerVal > 21)
                {
                    if (_pCStrand.Contains("AH") || _pCStrand.Contains("AD") || _pCStrand.Contains("AS") || _pCStrand.Contains("AC"))
                    {
                        _playerVal = _playerVal - 10;
                    }
                }
            }
            if (d == "9H" || d == "9D" || d == "9S" || d == "9C")
            {
                _playerVal = _playerVal + 9;
                if (_playerVal > 21)
                {
                    if (_pCStrand.Contains("AH") || _pCStrand.Contains("AD") || _pCStrand.Contains("AS") || _pCStrand.Contains("AC"))
                    {
                        _playerVal = _playerVal - 10;
                    }
                }
            }
            if (d == "TH" || d == "TD" || d == "TS" || d == "TC")
            {
                _playerVal = _playerVal + 10;
                if (_playerVal > 21)
                {
                    if (_pCStrand.Contains("AH") || _pCStrand.Contains("AD") || _pCStrand.Contains("AS") || _pCStrand.Contains("AC"))
                    {
                        _playerVal = _playerVal - 10;
                    }
                }
            }
            if (d == "JH" || d == "JD" || d == "JS" || d == "JC")
            {
                _playerVal = _playerVal + 10;
                if (_playerVal > 21)
                {
                    if (_pCStrand.Contains("AH") || _pCStrand.Contains("AD") || _pCStrand.Contains("AS") || _pCStrand.Contains("AC"))
                    {
                        _playerVal = _playerVal - 10;
                    }
                }
            }
            if (d == "QH" || d == "QD" || d == "QS" || d == "QC")
            {
                _playerVal = _playerVal + 10;
                if (_playerVal > 21)
                {
                    if (_pCStrand.Contains("AH") || _pCStrand.Contains("AD") || _pCStrand.Contains("AS") || _pCStrand.Contains("AC"))
                    {
                        _playerVal = _playerVal - 10;
                    }
                }
            }
            if (d == "KH" || d == "KD" || d == "KS" || d == "KC")
            {
                _playerVal = _playerVal + 10;
                if (_playerVal > 21)
                {
                    if (_pCStrand.Contains("AH") || _pCStrand.Contains("AD") || _pCStrand.Contains("AS") || _pCStrand.Contains("AC"))
                    {
                        _playerVal = _playerVal - 10;
                    }
                }
            }
            if (d == "AH" || d == "AD" || d == "AS" || d == "AC")
            {
                _playerVal = _playerVal + 11;
                if (_playerVal > 21)
                {

                    _playerVal = _playerVal - 10;

                }
            }
        }

        static void DealerValueUpdate(string d)
        {
            if (d == "2H" || d == "2D" || d == "2S" || d == "2C" || d == "2h" || d == "2d" || d == "2s" || d == "2c")
            {
                _dealerVal = _dealerVal + 2;
                if (_dealerVal > 21)
                {
                    if (_dCStrand.Contains("AH") || _dCStrand.Contains("AD") || _dCStrand.Contains("AS") || _dCStrand.Contains("AC"))
                    {
                        _dealerVal = _dealerVal - 10;
                    }
                }

            }
            if (d == "3H" || d == "3D" || d == "3S" || d == "3C")
            {
                _dealerVal = _dealerVal + 3;
                if (_dealerVal > 21)
                {
                    if (_dCStrand.Contains("AH") || _dCStrand.Contains("AD") || _dCStrand.Contains("AS") || _dCStrand.Contains("AC"))
                    {
                        _dealerVal = _dealerVal - 10;
                    }
                }

            }
            if (d == "4H" || d == "4D" || d == "4S" || d == "4C")
            {
                _dealerVal = _dealerVal + 4;
                if (_dealerVal > 21)
                {
                    if (_dCStrand.Contains("AH") || _dCStrand.Contains("AD") || _dCStrand.Contains("AS") || _dCStrand.Contains("AC"))
                    {
                        _dealerVal = _dealerVal - 10;
                    }
                }
            }
            if (d == "5H" || d == "5D" || d == "5S" || d == "5C")
            {
                _dealerVal = _dealerVal + 5;
                if (_dealerVal > 21)
                {
                    if (_dCStrand.Contains("AH") || _dCStrand.Contains("AD") || _dCStrand.Contains("AS") || _dCStrand.Contains("AC"))
                    {
                        _dealerVal = _dealerVal - 10;
                    }
                }
            }
            if (d == "6H" || d == "6D" || d == "6S" || d == "6C")
            {
                _dealerVal = _dealerVal + 6;
                if (_dealerVal > 21)
                {
                    if (_dCStrand.Contains("AH") || _dCStrand.Contains("AD") || _dCStrand.Contains("AS") || _dCStrand.Contains("AC"))
                    {
                        _dealerVal = _dealerVal - 10;
                    }
                }
            }
            if (d == "7H" || d == "7D" || d == "7S" || d == "7C")
            {
                _dealerVal = _dealerVal + 7;
                if (_dealerVal > 21)
                {
                    if (_dCStrand.Contains("AH") || _dCStrand.Contains("AD") || _dCStrand.Contains("AS") || _dCStrand.Contains("AC"))
                    {
                        _dealerVal = _dealerVal - 10;
                    }
                }
            }
            if (d == "8H" || d == "8D" || d == "8S" || d == "8C")
            {
                _dealerVal = _dealerVal + 8;
                if (_dealerVal > 21)
                {
                    if (_dCStrand.Contains("AH") || _dCStrand.Contains("AD") || _dCStrand.Contains("AS") || _dCStrand.Contains("AC"))
                    {
                        _dealerVal = _dealerVal - 10;
                    }
                }
            }
            if (d == "9H" || d == "9D" || d == "9S" || d == "9C")
            {
                _dealerVal = _dealerVal + 9;
                if (_dealerVal > 21)
                {
                    if (_dCStrand.Contains("AH") || _dCStrand.Contains("AD") || _dCStrand.Contains("AS") || _dCStrand.Contains("AC"))
                    {
                        _dealerVal = _dealerVal - 10;
                    }
                }
            }
            if (d == "TH" || d == "TD" || d == "TS" || d == "TC")
            {
                _dealerVal = _dealerVal + 10;
                if (_dealerVal > 21)
                {
                    if (_dCStrand.Contains("AH") || _dCStrand.Contains("AD") || _dCStrand.Contains("AS") || _dCStrand.Contains("AC"))
                    {
                        _dealerVal = _dealerVal - 10;
                    }
                }
            }
            if (d == "JH" || d == "JD" || d == "JS" || d == "JC")
            {
                _dealerVal = _dealerVal + 10;
                if (_dealerVal > 21)
                {
                    if (_dCStrand.Contains("AH") || _dCStrand.Contains("AD") || _dCStrand.Contains("AS") || _dCStrand.Contains("AC"))
                    {
                        _dealerVal = _dealerVal - 10;
                    }
                }
            }
            if (d == "QH" || d == "QD" || d == "QS" || d == "QC")
            {
                _dealerVal = _dealerVal + 10;
                if (_dealerVal > 21)
                {
                    if (_dCStrand.Contains("AH") || _dCStrand.Contains("AD") || _dCStrand.Contains("AS") || _dCStrand.Contains("AC"))
                    {
                        _dealerVal = _dealerVal - 10;
                    }
                }
            }
            if (d == "KH" || d == "KD" || d == "KS" || d == "KC")
            {
                _dealerVal = _dealerVal + 10;
                if (_dealerVal > 21)
                {
                    if (_dCStrand.Contains("AH") || _dCStrand.Contains("AD") || _dCStrand.Contains("AS") || _dCStrand.Contains("AC"))
                    {
                        _dealerVal = _dealerVal - 10;
                    }
                }
            }
            if (d == "AH" || d == "AD" || d == "AS" || d == "AC")
            {
                _dealerVal = _dealerVal + 11;
                if (_dealerVal > 21)
                {

                    _dealerVal = _dealerVal - 10;

                }


            }
        }

        static void Shuffle()
        {
            Random rnd = new Random();
            _deckArr = _cards.OrderBy(x => rnd.Next()).ToArray();
            for (int i = 0; i < _deckArr.Length; i++)
            {
                deck.Add(_deckArr[i]);
            }



        }

        static void PlayAgain()
        {
            if (_pMoney <= 0)
            {
                Environment.Exit(0);
            }
            if(_dMoney <= 0)
            {
                double debt = _pMoney - 300;
                Console.WriteLine("The Dealer is out of money and owes $" + debt);
                Console.ReadLine();
                Environment.Exit(0);
            }
            CountWins();
            Console.WriteLine("You have $" + _pMoney);
            Console.Write("Play Again ? : (Y or N) ");
            string user = Console.ReadLine();

            if (user == "Y" || user == "y")
            {

                Shuffle();
                _playerVal = 0;
                _dealerVal = 0;
                _pCStrand = "";
                _dCStrand = "";
                FirstHand();
            }
            if (user == "N" || user == "n")
            {
                Environment.Exit(0);
            }


        }

        static void CountWins()
        {
            Console.WriteLine("You Won " + _winCount + " times, Lost " + _lossCount + " times, and tied " + _tieCount + " times");
        }


    }

   

}
