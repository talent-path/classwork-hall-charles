import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-contact-form',
  templateUrl: './contact-form.component.html',
  styleUrls: ['./contact-form.component.css']
})
export class ContactFormComponent implements OnInit {

  constructor(private http : HttpClient) { }
  
  ngOnInit() {
  }

  onSubmit(contactForm: NgForm) {
    if (contactForm.valid) {
      const email = contactForm.value;
      const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
      this.http.post('https://formspree.io/f/mdoydvej',
        { name: email.name, replyto: email.email, message: email.messages },
        { 'headers': headers }).subscribe(
          response => {
            console.log(response);
          }
        );
    }
    var verifySent = <HTMLDivElement>document.getElementById("messageSent");
    verifySent.innerHTML = "Thank You! Your Message Has Been Sent.";
    this.clearForm();
  }

  clearForm()
  {
    (<HTMLFormElement>document.getElementById("contactForm")).reset();
  }

}
