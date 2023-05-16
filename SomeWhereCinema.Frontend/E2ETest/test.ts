import {Selector} from "testcafe";

fixture("Start Test")
  .page("https://somewherecinema-76ded.web.app/")
test('Movie Test',async t => {
  await t
    .click('body > app-root > span > a:nth-child(4)');
})
