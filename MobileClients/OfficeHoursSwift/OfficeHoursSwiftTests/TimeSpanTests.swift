//
//  TimeSpanTests.swift
//  OfficeHoursSwift
//
//  Created by Farkas Marton Imre on 27/05/16.
//  Copyright © 2016 WolferWolfy. All rights reserved.
//

import XCTest

class TimeSpanTests: XCTestCase {

    override func setUp() {
        super.setUp()
        // Put setup code here. This method is called before the invocation of each test method in the class.
    }
    
    override func tearDown() {
        // Put teardown code here. This method is called after the invocation of each test method in the class.
        super.tearDown()
    }

   func testExample() {
        // This is an example of a functional test case.
        // Use XCTAssert and related functions to verify your tests produce the correct results.
    }

    func testPerformanceExample() {
        // This is an example of a performance test case.
        self.measureBlock {
            // Put the code you want to measure the time of here.
        }
    }

    
    func testInitNoParams() {
        
        // given
        // when
        let timeSpan = TimeSpan()
        
        // then
        
        XCTAssertEqual(0, timeSpan.totalSeconds)
        XCTAssertEqual(0, timeSpan.hour)
        XCTAssertEqual(0, timeSpan.minute)
        XCTAssertEqual(0, timeSpan.second)
    }
    
    func testInitInterval() {
        
        // given
        let timeInterval = NSTimeInterval(3604)

        // when
        let timeSpan = TimeSpan(timeInterval: timeInterval)
        
        // then
        
        XCTAssertEqual(3604, timeSpan.totalSeconds)
        XCTAssertEqual(1, timeSpan.hour)
        XCTAssertEqual(0, timeSpan.minute)
        XCTAssertEqual(4, timeSpan.second)
    }
    
    func testInitTime() {
        
        // given
        let hour = 7
        let minute = 36
        let second = 30
        
        // when
        let timeSpan = TimeSpan(hour: hour, minute: minute, second: second)
        
        // then
        
        XCTAssertEqual(hour*60*60 + minute*60 + second, timeSpan.totalSeconds)
        XCTAssertEqual(hour, timeSpan.hour)
        XCTAssertEqual(minute, timeSpan.minute)
        XCTAssertEqual(second, timeSpan.second)
    }
    
    func testAddInterval() {
        
        // given
        var timeSpan = TimeSpan(hour: 7, minute: 30, second: 15)
        let seconds = 15 * 60 + 20;
        let interval = NSTimeInterval(seconds)
        
        // when
        
        timeSpan.addTimeInterval(interval)
        
        // then
        
        XCTAssertEqual(7 * 3600 + 30 * 60 + 15 + seconds , timeSpan.totalSeconds)
        XCTAssertEqual(7, timeSpan.hour)
        XCTAssertEqual(45, timeSpan.minute)
        XCTAssertEqual(35, timeSpan.second)
    }
    
    func testSubtractInterval() {
        
        // given
        var timeSpan = TimeSpan(hour: 7, minute: 30, second: 15)
        let seconds = 15 * 60 + 20;
        let interval = NSTimeInterval(seconds)
        
        // when
        
        timeSpan.subtractTimeInterval(interval)
        
        // then
        
        XCTAssertEqual(7 * 3600 + 30 * 60 + 15 - seconds , timeSpan.totalSeconds)
        XCTAssertEqual(7, timeSpan.hour)
        XCTAssertEqual(14, timeSpan.minute)
        XCTAssertEqual(55, timeSpan.second)
    }
    
    func testAddTimeSpan() {
        
        // given
        var timeSpan = TimeSpan(hour: 7, minute: 30, second: 15)
        let timeSpan2 = TimeSpan(hour: 0, minute: 15, second: 20)
        
        // when
        
        timeSpan.addTimeSpan(timeSpan2)
        
        // then
        
        XCTAssertEqual(7 * 3600 + 30 * 60 + 15 + 15 * 60 + 20 , timeSpan.totalSeconds)
        XCTAssertEqual(7, timeSpan.hour)
        XCTAssertEqual(45, timeSpan.minute)
        XCTAssertEqual(35, timeSpan.second)
    }
    func testSubtractTimeSpan() {
        
        // given
        var timeSpan = TimeSpan(hour: 7, minute: 30, second: 15)
        let timeSpan2 = TimeSpan(hour: 0, minute: 15, second: 20)
        
        // when
        
        timeSpan.subtractTimeSpan(timeSpan2)
        
        // then
        
        XCTAssertEqual(7 * 3600 + 30 * 60 + 15 - 15 * 60 - 20 , timeSpan.totalSeconds)
        XCTAssertEqual(7, timeSpan.hour)
        XCTAssertEqual(14, timeSpan.minute)
        XCTAssertEqual(55, timeSpan.second)
    }

}
