import { ThisReceiver } from '@angular/compiler';
import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
})
export class AppComponent {
  title = 'BookStore'
  URI = 'http://localhost:4200'

  isCartOpen: boolean = false   
  isCancelButtonVisible: boolean = false
  cart: any = {}
  pendingOrder: any = {}
  price: number = 0
  books: any

  timer: any

  async ngOnInit() {
    await fetch('/book')
    .then((response) => {
      return response.json()
    })
    .then((data) => {
      this.books = data
    })
  }

  isEmptyObject(object: object) {
    return (object && (Object.keys(object).length === 0))
  }

  addToCart(book: any) {
    if (book.availableAmount > 0) {
      book.availableAmount--
      if (book.name in this.cart) {
        this.cart[book.name]++
      } else {
        this.cart[book.name] = 1
      }

      this.price += book.price

      return
    }
    
    window.alert(`${book.name} out of stock. Cant be added to cart`)
  }

  async refreshBooks() {
    await fetch('/book')
    .then((response) => {
      return response.json()
    })
    .then((data) => {
      this.books = data
    })
  }

  cartClicked(cartState: boolean) {
    this.isCartOpen = !cartState
  }

  removeFromCart(bookName: any, cart: any) {
    cart[bookName]--
    if (cart[bookName] <= 0) {
      delete cart[bookName]
    }

    for (let book of this.books){
      if (book.name === bookName) {
        book.availableAmount++

        if (this.price !== 0) {
        this.price -= book.price
        }
      }
    }
  }

  discountCheck(price: number) {
    if (price > 1000) {
      return Math.round(price * 95) / 100
    } else {
      return price
    }
  }

  checkout() {
    const clientName = window.prompt('Enter your name.')
    if (!clientName) {
      window.alert('You must enter you name in order to confirm your order')
      return
    }
    
    this.pendingOrder = this.cart
    this.cart = {}
    const pendingPrice = this.price
    this.price = 0

    window.alert('Your order placed. You have a minute to cancel your order.')
    this.isCancelButtonVisible = true
    this.timer = setTimeout(() => { 
      this.isCancelButtonVisible = false

      const orderedBooks: any = []
      for (let item in this.pendingOrder) {
        let isbn
        let price 

        for (const book of this.books) {
          if (book.name === item) {
            isbn = book.isbn
            price = book.price
          }
        }

        orderedBooks.push({ isbn: isbn, name: item, amount: this.pendingOrder[item], price: price })
      }

      const confirmedOrder = {
        buyerName: clientName,
        price: pendingPrice,
        items: orderedBooks
      }
      this.sendConfirmedOrder(confirmedOrder)
    }, 10000)
  }

  sendConfirmedOrder(confirmedOrder: any) {
    fetch('/book', {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json'
      },
      body: JSON.stringify(this.books)
    })

    fetch('/order', {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json'
      },
      body: JSON.stringify(confirmedOrder)
    })
  }

  cancelOrder() {
    clearTimeout(this.timer)
    for (const orderedItem in this.pendingOrder) {
      const count = this.pendingOrder[orderedItem]

      for (let i: number = 0; i < count; i++) {
        this.removeFromCart(orderedItem, this.pendingOrder)
      }

      this.isCancelButtonVisible = false;
    }
  }
}
