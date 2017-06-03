import { CoreWithAngularPage } from './app.po';

describe('core-with-angular App', () => {
  let page: CoreWithAngularPage;

  beforeEach(() => {
    page = new CoreWithAngularPage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
