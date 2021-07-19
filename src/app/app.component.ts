import { ThisReceiver } from '@angular/compiler';
import { Component } from '@angular/core';
import { books } from './source-placeholder'

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
})
export class AppComponent {
  books = books

  isCartOpen: boolean = false   
  isCancelButtonVisible: boolean = false
  public cart: any = {}
  price: number = 0

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

  refreshBooks() {
    window.alert('Website will make a server request and refresh books on page. Placeholder for now')
  }

  cartClicked(cartState: boolean) {
    this.isCartOpen = !cartState
  }

  removeFromCart(bookName: any) {
    this.cart[bookName]--
    if (this.cart[bookName] <= 0) {
      delete this.cart[bookName]
    }

    for (let book of this.books){
      if (book.name === bookName) {
        book.availableAmount++
        this.price -= book.price
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

    window.alert('Your order placed. You have a minute to cancel your order.')
    this.isCancelButtonVisible = true
    setTimeout(() => { this.isCancelButtonVisible = false}, 10000)
  }

  cancelOrder() {
    for (const cartOrder in this.cart) {
      const count = this.cart[cartOrder]

      for (let i: number = 0; i < count; i++) {
        this.removeFromCart(cartOrder)
      }

      this.isCancelButtonVisible = false;
    }
  }
}
