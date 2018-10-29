import XCTest
@testable import nullObject

final class NullObjectTests: XCTestCase {

    func testFacebookLoginSuccess() {
        let sut = LoginFactory()
        let loginService = sut.getService(ofType: LoginFactory.ServiceType.facebook)
        let loginSuccess = loginService.login()
        XCTAssertTrue(loginSuccess)
    }

    func testGoogleLoginSuccess() {
        let sut = LoginFactory()
        let loginService = sut.getService(ofType: LoginFactory.ServiceType.google)
        let loginSuccess = loginService.login()
        XCTAssertTrue(loginSuccess)
    }

    static var allTests = [
        ("testFacebookLoginSuccess", testFacebookLoginSuccess),
        ("testGoogleLoginSuccess", testGoogleLoginSuccess),
    ]

}
