// NOTE: The comment sections inside the index.html file is an example of how suppose to be structured the current elements.
//       - You can use them as an example when you create those elements, to check how they will be displayed, just uncomment them.
//       - Also keep in mind that, the actual skeleton in judge does not have this comment sections. So do not be dependent on them!
//       - Тhey are present in the skeleton just to help you!


// This function will be invoked when the html is loaded. Check the console in the browser or index.html file.
function mySolution() {
    const elements = {
        askQuestionTextArea: document.querySelector('#inputSection textarea'),
        usernameInputField: document.querySelector('#inputSection div input[type="username"]'),
        askQuestionButton: document.querySelector('#inputSection div button'),
        pendingQuestionDiv: document.querySelector('#pendingQuestions'),
        openQuestionDiv: document.querySelector('#openQuestions'),
    }

    elements.askQuestionButton.addEventListener('click', askQuestion);

    function askQuestion() {
        const question = elements.askQuestionTextArea.value;
        const givenUserName = elements.usernameInputField.value;
        const username = givenUserName !== "" ? givenUserName : "Anonymous";

        let pendingQDiv = createHtmlElement('div', 'pendingQuestion');
        let usernameImage = createHtmlElement('img', null, null,
            [
                { k: 'src', v: './images/user.png' },
                { k: 'width', v: 32 },
                { k: 'height', v: 32 },
            ]
        );

        let usernameSpan = createHtmlElement('span', null, username);
        let questionP = createHtmlElement('p', null, question);
        let actionsDiv = createHtmlElement('div', 'actions');
        let archiveBtn = createHtmlElement('button', 'archive', 'Archive', null, { name: 'click', func: archiveQuestion });
        let opneBtn = createHtmlElement('button', 'open', 'Open', null, { name: 'click', func: opneQuestion });


        actionsDiv = appendChildrenToParent([archiveBtn, opneBtn], actionsDiv);
        pendingQDiv = appendChildrenToParent([usernameImage, usernameSpan, questionP, actionsDiv], pendingQDiv);

        elements.pendingQuestionDiv.appendChild(pendingQDiv);

    }

    function archiveQuestion(e) {
        const parent = e.target.parentNode.parentNode;
        parent.remove();
    }

    function opneQuestion(e) {
        const questionDiv = e.target.parentNode.parentNode;
        questionDiv.className = "openQuestion";
        let actionsDiv = questionDiv.querySelector('div.actions');
        actionsDiv.innerHTML = "";
        let replyBtn = createHtmlElement('button', 'reply', 'Reply', null, { name: 'click', func: replyQuestion });
        actionsDiv = appendChildrenToParent([replyBtn], actionsDiv);


        let replySectionDiv = createHtmlElement('div', 'replySection', null, [{ k: 'style', v: "display: none;" }]);
        let input = createHtmlElement('input', 'replyInput', null,
            [
                { k: 'type', v: "text" },
                { k: 'placeholder', v: 'Reply to this question here...' }
            ]);

        let sendBtn = createHtmlElement('button', 'replyButton', 'Send', null, { name: 'click', func: addReply });
        let answerOl = createHtmlElement('ol', 'reply', null, [{ k: 'type', v: '1' }]);

        replySectionDiv = appendChildrenToParent([input, sendBtn, answerOl], replySectionDiv)

        questionDiv.appendChild(replySectionDiv);

        elements.openQuestionDiv.appendChild(questionDiv);
    }

    function replyQuestion(e) {
        const button = e.target;
        const replySectionDiv = this.parentNode.parentNode.querySelector('.replySection');

        if (button.textContent === "Reply") {
            replySectionDiv.style.display = "block";
            button.textContent = "Back";
        }else{
            replySectionDiv.style.display = "none";
            button.textContent = "Reply";
        }
    }

    function addReply() {
        const parent = this.parentNode;
        const answerInput = parent.querySelector('input').value;

        let naswerLi = createHtmlElement('li', null, answerInput);

        parent.querySelector('ol').appendChild(naswerLi);
    }

    function createHtmlElement(tagName, className, textContent, attributes, event) {
        let element = document.createElement(tagName);

        if (className) {
            element.classList.add(className);
        }

        if (textContent) {
            element.textContent = textContent;
        }

        if (attributes) {
            attributes.forEach(a => {
                element.setAttribute(a.k, a.v);
            });
        }
        if (event) {
            element.addEventListener(event.name, event.func);
        }

        return element;
    }

    function appendChildrenToParent(children, parent) {
        children.forEach(child => {
            parent.appendChild(child);
        });

        return parent;
    }
}