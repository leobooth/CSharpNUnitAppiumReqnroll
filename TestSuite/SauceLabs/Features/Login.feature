Feature: Login

  Scenario: Successful Login and Logout
    Given the Catalog screen is visible
     When I log in as user "bod@example.com" with password "10203040"
     Then the Catalog screen is visible
     When I log out
     Then the Login screen is visible
     # test cleanup
     When I open the sidebar menu
      And I click the Catalog button
     Then the Catalog screen is visible