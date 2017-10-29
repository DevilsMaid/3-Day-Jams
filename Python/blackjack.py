import random
import sys
import os

SUITS = ['♥', '♦', '♠', '♣']
RANKS = ['2', '3', '4', '5', '6', '7', '8', '9', '10', 'J', 'Q', 'K', 'A']

class Card:
	def __init__(self, suit, rank):
		self.suit = suit;
		self.rank = rank;
		
		if rank == 'A':
			self.point = 11
		elif rank in ['K', 'Q', 'J']:
			self.point = 10
		else:
			self.point = int(rank)
		self.hidden = False
			
	def __str__(self):
		if self.hidden:
			return '[X]'
		else:
			return '[' + self.suit + ' ' + self.rank + ']'
	
	def hide_card(self):
		self.hidden = True
	
	def points(self):
		return self.point

	def reveal_card(self):
		self.hidden = False

	def is_ace(self):
		return self.rank == 'A'

class Deck:
	
	def __init__(self):
		self.cards = [Card(suit, rank) for suit in SUITS for rank in RANKS]
		self.shuffle()

	def __str__(self):
		cards_in_deck = ''
		for card in self.cards:
			cards_in_deck = cards_in_deck + str(card) + ' '
		return cards_in_deck

	def shuffle(self):
		random.shuffle(self.cards)
	
	def shuffle_card_in(self, card):
		self.cards.append(card)
	
	def deal_card(self):
		card = self.cards.pop(0)
		return card
	
	def is_empty(self):
		if not self.cards:
			return True
		return False

class Grave:
	def __init__(self):
		self.cards = []
	
	def add_to_grave(self, card):
		self.cards.append(card)
	
	def refill_deck(self, deck):
		for card in self.cards:
			deck.shuffle_card_in(card)
		deck.shuffle()
		while self.cards:
			self.cards.pop(0)

class Hand:
	def __init__(self):
		self.cards = []
		self.unused_aces_count = 0
		self.points = 0
	
	def evaluate(self):
		return self.points
	
	def __str__(self):
		cards_in_hand = ''
		for card in self.cards:
			cards_in_hand = cards_in_hand + str(card) + ' '
		return cards_in_hand
		
	def hide_second(self):
		self.cards[1].hide_card()
		
	def reveal_second(self):
		self.cards[1].reveal_card()
	
	def add_to_hand(self, card):
		self.cards.append(card)
		self.points += card.points();
		if card.is_ace():
			self.unused_aces_count += 1
		while self.points > 21 and self.unused_aces_count != 0:
			self.points -= 10
			self.unused_aces_count -= 1
		
	def discard_hand(self, grave):
		for card in self.cards:
			grave.add_to_grave(card)
		while self.cards:
			self.cards.pop(0)
		self.unused_aces_count = 0
		self.points = 0

def give_card(player, deck, grave):
	if deck.is_empty():
		grave.refill_deck(deck)
	player.add_to_hand(deck.deal_card())
			
def play_game():
	deck = Deck()
	dealer = Hand()
	player = Hand()
	graveyard = Grave()
	credits = 100
	
	os.system('cls' if os.name == 'nt' else 'clear')
	print(" Welcome to BlackJack")
	
	while True:
		
		if credits == 0:
			break
		
		print ("\n","You have",credits,"$. You can play or you can quit")
		
		command_main = input("\n What will you do?: ")
		if command_main == "play":
			
			bet=0
			while True:
				bet = int(input ("\n How much will you bet?: "))
				if bet > credits or bet<=0:
					print("\b"*120,end='\r')
					print(" "*120)
					print("\b"*120*2,end='\r')
				else:
					break
			
			give_card(dealer,deck,graveyard)
			give_card(dealer,deck,graveyard)
			dealer.hide_second()
			
			give_card(player,deck,graveyard)
			give_card(player,deck,graveyard)
			
			while True:
				os.system('cls' if os.name == 'nt' else 'clear')
				print("\n","Dealer hand: ",dealer)
				print("\n","Player hand: ",player, " Current score: ", player.evaluate())
				if player.evaluate() > 21:
					break
				command = input("\n What will you do?: ")
				if command == "hit":
					give_card(player,deck,graveyard)
				elif command == "stand":
					break
			
			dealer.reveal_second()
			while True and player.evaluate() <= 21:
				os.system('cls' if os.name == 'nt' else 'clear')
				print("\n","Dealer hand: ",dealer, " Dealer's score: ", dealer.evaluate())
				print("\n","Player hand: ",player, " Current score: ", player.evaluate())
				if dealer.evaluate() >= 17:
					break
				give_card(dealer,deck,graveyard)
				
			if(player.evaluate() > 21):
				print ("\n","   You BUST")
				credits -= bet
			elif(dealer.evaluate() > 21):
				print ("\n","   Dealer BUST")
				credits += bet
			elif(player.evaluate() < dealer.evaluate()):
				print ("\n","   Dealer WINS")
				credits -= bet
			elif(player.evaluate() > dealer.evaluate()):
				print ("\n","   You WIN")
				credits += bet
			elif(player.evaluate() == dealer.evaluate()):
				print ("\n","   Draw")
			
			dealer.discard_hand(graveyard)
			player.discard_hand(graveyard)
			
			
		elif command_main == "quit":
			break
		else:
			print("\b"*120,end='\r')
			print(' '*120)
			print("\b"*120*4,end='\r')
	
	print('\n','You ended with',credits,'$!')
		
new_deck = Deck()
print(new_deck)
for i in range(40):
	print(new_deck.deal_card())
print(new_deck)

play_game()
