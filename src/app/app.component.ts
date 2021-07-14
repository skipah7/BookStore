import { Component } from '@angular/core';
import { books } from './source-placeholder'

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
})
export class AppComponent {
  title = 'BookStore';

  books = books

  addToCart(bookName: string) {
    window.alert(`${bookName} will be added to shopping cart. Placeholder for now`)
  }

  refreshBooks() {
    window.alert('Website will make a server request and refresh books on page. Placeholder for now')
  }
}
