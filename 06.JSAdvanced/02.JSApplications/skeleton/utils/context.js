export default function (context) {
    firebase.auth().onAuthStateChanged(function (user) {
        if (user) {
            // User is signed in.
            // var displayName = user.displayName;
            // var email = user.email;
            // var emailVerified = user.emailVerified;
            // var photoURL = user.photoURL;
            // var isAnonymous = user.isAnonymous;
            // var uid = user.uid;
            // var providerData = user.providerData;
            context.userId = user.uid;
            context.username = user.email;
            context.isLoggedIn = true;

            localStorage.setItem('userId', user.uid);
            localStorage.setItem('userEmail', user.email);
            // ...
        } else {
            // User is signed out.
            context.userId = null;
            context.username = null;
            context.isLoggedIn = false;
            localStorage.removeItem('userId');
            localStorage.removeItem('userEmail');

        }
    });

    return context.loadPartials({
        header: "../views/common/header.hbs",
        footer: "../views/common/footer.hbs",
    });
}