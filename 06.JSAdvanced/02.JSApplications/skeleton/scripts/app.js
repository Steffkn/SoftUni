import controllers from '../controllers/index.js';

const app = Sammy('#root', function(){
    this.use('Handlebars', 'hbs');

    // home
    this.get('#/home', controllers.home.get.home);

    //user
    this.get('#/user/login', controllers.user.get.login);
    this.get('#/user/register', controllers.user.get.register);
    this.get('#/user/logout', controllers.user.get.logout);

    this.post('#/user/login', controllers.user.post.login);
    this.post('#/user/register', controllers.user.post.register);

    // couse
    this.get('#/cause/create', controllers.cause.get.create);
    this.get('#/cause/dashboard', controllers.cause.get.dashboard);
    this.get('#/cause/details/:causeId', controllers.cause.get.details);
    this.post('#/cause/create', controllers.cause.post.create);

    this.get('#/cause/close/:causeId', controllers.cause.del.close);
    this.post('#/cause/donate/:causeId', controllers.cause.put.donate);
});

(()=>{
    app.run('#/home');
})();