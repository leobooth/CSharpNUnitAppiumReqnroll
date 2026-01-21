Feature: About

  Scenario: Check version number
    Given the Catalog screen is visible
     When I open the sidebar menu
      And I click the About button
     Then the About screen is visible
      And the version number is "V.2.2.0-build 25"
    # test cleanup
     When I open the sidebar menu
      And I click the Catalog button
     Then the Catalog screen is visible