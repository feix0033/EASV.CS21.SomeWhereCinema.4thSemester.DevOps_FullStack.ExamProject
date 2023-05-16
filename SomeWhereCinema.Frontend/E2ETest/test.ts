import {Selector} from "testcafe";

fixture("Start Test");

test.page("https://somewherecinema-76ded.web.app/")
  ('Home link test',async t => {
    await t
      .click('body > app-root > span > a:nth-child(2)')
      .expect(Selector('body > app-root > app-homepage > p').innerText).eql("homepage works!")
      .takeScreenshot()
  })

test.page("https://somewherecinema-76ded.web.app/")
  ('User link test',async t => {
    await t
      .click('body > app-root > span > a:nth-child(3)')
      .expect(Selector('body > app-root > app-user-info > p').innerText).eql("user-info works!")
      .takeScreenshot()
  })

test.page("https://somewherecinema-76ded.web.app/")
  ('Movie link test',async t => {
    await t
      .click('body > app-root > span > a:nth-child(4)')
      .expect(Selector('body > app-root > app-movie-info > p').innerText).eql("movie-info works!")
      .takeScreenshot()
  })
