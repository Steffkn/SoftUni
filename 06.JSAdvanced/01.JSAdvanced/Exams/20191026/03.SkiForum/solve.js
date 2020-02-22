class Forum {
    // TODO: implement this class...

    constructor() {
        this.users = [];
        this.questions = [];
        this.id = 1;
    }

    register(username, password, repeatPassword, email) {
        if (this.isEmptyString(username) ||
            this.isEmptyString(password) ||
            this.isEmptyString(repeatPassword) ||
            this.isEmptyString(email)) {
            throw new Error("Input can not be empty");
        }

        if (password !== repeatPassword) {
            throw new Error("Passwords do not match");
        }

        if (this.users.length > 0) {
            if (this.users.some((u) => u.username === username || u.email === email)) {
                throw new Error("This user already exists!");
            }
        }

        this.users.push({
            username: username,
            password: password,
            email: email,
            login: false,
        });

        return `${username} with ${email} was registered successfully!`;
    }

    login(username, password) {
        let user = this.findUser(username, password);
        if (user.password === password) {
            user.login = true;
            return "Hello! You have logged in successfully";
        }
    }

    logout(username, password) {
        let user = this.findUser(username, password);
        if (user.password === password) {
            user.login = false;
            return "You have logged out successfully";
        }
    }

    postQuestion(username, question) {
        if (this.isEmptyString(question)) {
            throw new Error("Invalid question");
        }

        let user = this.getUser(username);
        if (!user) {
            throw new Error("You should be logged in to post questions");
        }

        this.questions.push({
            question: question,
            questionId: this.id,
            username: username
        });
        this.id += 1;

        return "Your question has been posted successfully";
    }

    postAnswer(username, questionId, answer) {
        if (this.isEmptyString(answer)) {
            throw new Error("Invalid answer");
        }

        let user = this.getUser(username);
        if (!user) {
            throw new Error("You should be logged in to post answers");
        }

        let question = this.questions.find((q) => q.questionId === questionId);
        if (!question) {
            throw new Error("There is no such question");
        }

        if (!question.hasOwnProperty("answers")) {
            question.answers = [];
        }

        question.answers.push({ username: user.username, answer: answer });

        return "Your answer has been posted successfully";
    }


    showQuestions() {
        let result = "";
        for (let index = 0; index < this.questions.length; index++) {
            const qq = this.questions[index];

            result = result.concat(`Question ${qq.questionId} by ${qq.username}: ${qq.question}\n`);

            for (let answrIndex = 0; answrIndex < qq.answers.length; answrIndex++) {
                const aa = qq.answers[answrIndex];
                result = result.concat(`---${aa.username}: ${aa.answer}\n`);
            }
        }

        return result.trim();
    }

    getUser(username) {
        let user = this.users.find((u) => u.username === username && u.login === true);

        return user;
    }

    findUser(username) {
        let user = this.users.find((u) => u.username === username);
        if (!user) {
            throw new Error("There is no such user");
        }
        return user;
    }

    isEmptyString(variable) {
        return variable === "";
    }
}