let SkiResort = require('./solution');
let assert = require("chai").assert;

describe('SkiResort', function () {
    let skiResort;
    let skiResortName = 'Osogovo';

    beforeEach(function () {
        skiResort = new SkiResort(skiResortName);
    });

    //TODO... =)
    describe("Constructor tests", function () {
        it("init values proper", function () {
            assert.equal(skiResort.name, skiResortName);
            assert.equal(skiResort.voters, 0);
            assert.deepEqual(skiResort.hotels, []);
        });
        it("should return proper message if no voters are present", function () {
            assert.equal(skiResort.bestHotel, "No votes yet");
        });
        it("should return proper message when there are votes", function () {
            skiResort.build("Sun", 10);
            skiResort.build('Avenue', 5);
            skiResort.book('Sun', 5);
            skiResort.book('Avenue', 5);
            skiResort.leave('Sun', 3, 2);
            skiResort.leave('Avenue', 3, 3);
            skiResort.book('Avenue', 3);
            skiResort.leave('Avenue', 3, 0.5);
            assert.equal(skiResort.bestHotel, "Best hotel is Avenue with grade 10.5. Available beds: 3");
        });
    });

    //TODO... =)
    describe("testing build()", function () {
        it("input validation tests", function () {
            assert.throw(function () {
                skiResort.build('', -10);
            }, "Invalid input");
            assert.throw(function () {
                skiResort.build('', 10);
            }, "Invalid input");
            assert.throw(function () {
                skiResort.build("Opa", -10);
            }, "Invalid input");
        });

        it("input with valid values tests", function () {
            skiResort.build("Sun", 10);
            assert.equal(skiResort.hotels.length, 1);
            assert.equal(skiResort.hotels[0].name, "Sun");
            assert.equal(skiResort.hotels[0].beds, 10);
        });

        it("input with valid values tests returns proper message", function () {
            let name = "object";
            assert.equal(skiResort.build(name, 10), `Successfully built new hotel - ${name}`);
        });
    });

    describe("testing book()", function () {
        it("input validation tests", function () {
            assert.throw(function () {
                skiResort.book('', -10);
            }, "Invalid input");
            assert.throw(function () {
                skiResort.book('', 10);
            }, "Invalid input");
            assert.throw(function () {
                skiResort.book("Opa", -10);
            }, "Invalid input");
        });

        it("invalid arrange input with valid values tests", function () {
            let name = "alabala"
            assert.throw(function () {
                skiResort.book(name, 10);
            }, "There is no such hotel");

            skiResort.build(name, 1)

            assert.throw(function () {
                skiResort.book(name, 2);
            }, "There is no free space");
        });

        it("valid arrange input with valid values tests should return proper message", function () {
            let name = "alabala"
            skiResort.build(name, 1)
            assert.equal(skiResort.book(name, 1), "Successfully booked");
            assert.equal(skiResort.hotels[0].beds, 0);
        });

    });


    describe("testing leave()", function () {
        it("input validation tests", function () {
            assert.throw(function () {
                skiResort.leave('', 0, 0);
            }, "Invalid input");
            assert.throw(function () {
                skiResort.leave('', 1, 0);
            }, "Invalid input");
            assert.throw(function () {
                skiResort.leave("Opa", 0, 0);
            }, "Invalid input");
        });

        it("invalid arrange input with valid values tests", function () {
            let name = "alabala"
            assert.throw(function () {
                skiResort.leave(name, 1, 0);
            }, "There is no such hotel");
        });

        it("valid arrange input with valid values tests should return proper message", function () {
            let name = "alabala"
            let totalBeds = 2;
            let bookedBeds = 2;
            let pointsGiven = 4;
            skiResort.build(name, totalBeds);
            skiResort.book(name, bookedBeds);
            
            assert.equal(skiResort.leave(name, bookedBeds, pointsGiven), `${bookedBeds} people left ${name} hotel`);
            assert.equal(skiResort.hotels[0].beds, totalBeds);
            assert.equal(skiResort.hotels[0].points, bookedBeds * pointsGiven);
            assert.equal(skiResort.voters, bookedBeds);
        });
    });
    

    describe("testing averageGrade()", function () {
        it("valid arrange input should return proper message", function () {
           assert.equal(skiResort.averageGrade(), "No votes yet");
        });
        
        it("valid arrange input with valid values tests should return proper message", function () {
            skiResort.build("Sun", 10);
            skiResort.build('Avenue', 5);
            skiResort.book('Sun', 5);
            skiResort.book('Avenue', 5);
            skiResort.leave('Sun', 3, 2);
            skiResort.leave('Avenue', 3, 3);
            skiResort.book('Avenue', 3);
            skiResort.leave('Avenue', 3, 0.5);
            assert.equal(skiResort.averageGrade(), "Average grade: 1.83");
        });
    });
});
