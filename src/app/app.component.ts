import { ThisReceiver } from '@angular/compiler';
import { Component } from '@angular/core';
import { books } from './source-placeholder'

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
})
export class AppComponent {
  title = 'BookStore';

  books = books
  cartState: boolean = false   
  cancelButton: boolean = false
  cart: any = {}
  price: number = 0

  addToCart(book: any) {
    if (book.availableAmount > 0) {
      book.availableAmount--
      if (book.name in this.cart) {
        this.cart[book.name]++
      } else {
        this.cart[book.name] = 1
      }
      console.log(this.cart)

      this.price += book.price

      return
    }
    
    window.alert(`${book.name} out of stock. Cant be added to cart`)
  }

  refreshBooks() {
    window.alert('Website will make a server request and refresh books on page. Placeholder for now')
  }

  cartClicked(cartState: boolean) {
    this.cartState = !cartState
  }

  removeFromCart(bookName: any) {
    if (--this.cart[bookName] == 0) {
      delete this.cart[bookName]
    }
    console.log(this.cart)

    for (let book of this.books){
      if (book.name == bookName) {
        book.availableAmount++
        this.price -= book.price
      }
    }
  }

  discountCheck(price: number) {
    if (price > 1000) {
      return Math.round(price * 0.95)
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

    window.alert('Your order placed. You have a minute to cancel your order.')
    this.cancelButton = true
    setTimeout(() => { this.cancelButton = false}, 10000)
  }

  cancelOrder() {
    for (const cartOrder in this.cart) {
      for (let i = 0; i <= this.cart[cartOrder] + 1; i++) {
        this.removeFromCart(cartOrder)
      }

      this.cancelButton = false;
    }
  }
}
