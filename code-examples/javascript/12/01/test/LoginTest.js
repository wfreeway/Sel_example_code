require('./spec_helper')
const assert = require('assert')
const LoginPage = require('../pages/LoginPage')

describe('Login', function() {
  let login

  beforeEach(async function() {
    login = new LoginPage(this.driver)
    await login.load()
  })

  it('with valid credentials', async function() {
    await login.authenticate('tomsmith', 'SuperSecretPassword!')
    assert(await login.successMessagePresent(), 'Success message not displayed')
    await this.eyes.checkWindow('Logged in')
    await this.eyes.close()
  })

  it('with invalid credentials', async function() {
    await login.authenticate('tomsmith', 'bad password')
    assert(await login.failureMessagePresent(), 'Failure message not displayed')
    //assert(await !login.isSuccessMessagePresent(), 'Success message displayed')
    await this.eyes.checkWindow('Incomplete Login')
    await this.eyes.close()
  })
})