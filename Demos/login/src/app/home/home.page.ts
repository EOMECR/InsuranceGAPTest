import { NavController } from '@ionic/angular';
import { Component } from '@angular/core';
import { Facebook, FacebookLoginResponse } from '@ionic-native/facebook/ngx';
import { GooglePlus } from '@ionic-native/google-plus/ngx';
import { TwitterConnect } from '@ionic-native/twitter-connect/ngx';
import { AngularFireAuth } from 'angularfire2/auth';
import * as firebase from 'firebase';
import { AngularFirestore } from '@angular/fire/firestore';
import { Router } from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: 'home.page.html',
  styleUrls: ['home.page.scss'],
})
export class HomePage {
  user:any = {};
  userData = null;
  userDataG = null;
  userDataT = null;

  twitterData = {
    loggedin: false,
    name: '',
    email: '',
    profilePicture: '',
    username: ''
  }


  constructor(public Navctr: NavController, private facebook : Facebook, private googlePlus: GooglePlus, private twitter: TwitterConnect, private fire: AngularFireAuth,private db:AngularFirestore, public router : Router) {}

 loginFacebook()
  {
    this.facebook.login(['email','public_profile']).then((response : FacebookLoginResponse) => {
      this.facebook.api('me?fields=id,name,email,first_name,picture.width(720).height(720).as(picture_large)',[]).then(profile => {
        this.userData = {email:profile['email'], first_name:profile['first_name'], picture:profile['picture_large']['data']['url'], username:profile['name']}
      })
    })
  }
  googleLogin() {
    this.googlePlus.login({})
      .then(result => {this.userDataG = result})
      .catch(err => this.userDataG = `Error ${JSON.stringify(err)}`);
      console.log(this.userDataG);
      
  }
  twitterLogin()
  {
    this.twitter.login().then(res => {
    //console.log(res);
    this.twitter.showUser().then(result => {console.log(result); }).catch(err => this.userDataT = err);

    /*this.fire.auth.signInWithPopup(new firebase.auth.TwitterAuthProvider())
   .then(res => {
     console.log(res);
     this.twitterData.loggedin = true;
     this.twitterData.name = res.user.displayName;
     this.twitterData.email = res.user.email;
     this.twitterData.profilePicture = res.user.photoURL;
     this.twitterData.username = res.additionalUserInfo.username;
   })*/
  })
  }
  googleLogout()
  {
    this.googlePlus.logout();
  }
  facebookLogout()
  {
    this.facebook.logout();
  }
}