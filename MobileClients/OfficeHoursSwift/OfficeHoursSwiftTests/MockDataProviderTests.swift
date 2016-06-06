//
//  MockDataProviderTests.swift
//  OfficeHoursSwift
//
//  Created by Farkas Marton Imre on 03/06/16.
//  Copyright © 2016 WolferWolfy. All rights reserved.
//

import XCTest

class MockDataProviderTests: XCTestCase {

    var provider: MockDataProvider?

    override func setUp() {
        super.setUp()
        // Put setup code here. This method is called before the invocation of each test method in the class.
       provider =  MockDataProvider.sharedInstance2
    }
    
    override func tearDown() {
        // Put teardown code here. This method is called after the invocation of each test method in the class.
        super.tearDown()
    }

    func testConversion() {
        // This is an example of a functional test case.
        // Use XCTAssert and related functions to verify your tests produce the correct results.

        let m = MockDataProvider.sharedInstance2.entriesToMonths(MockDataProvider.sharedInstance2.userEntries)
        
        XCTAssertEqual(2, m?.count)
        //TODO: extend test, write more test cases
        
    }


}
